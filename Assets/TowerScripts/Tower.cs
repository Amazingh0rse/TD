using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public GameObject cannonballPrefab;
    public AudioSource audioComp;
    public AudioClip fireSound;
    public float fireSoundVolume = 0.25f;
    bool inTrigger = false;
    float lastCheck = 0.0f;
    float checkInterval = 1f;

    public float turnSpeed = 10f;

    public Transform partToRotate;
    private Transform target = null;

    public float range = 12f;

    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
        audioComp = GetComponent<AudioSource>();
        audioComp.playOnAwake = false;
        audioComp.clip = fireSound;
        audioComp.volume = fireSoundVolume;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void OnTriggerStay(Collider col)
    {
        inTrigger = true;
        if (col.tag == "Enemy" && inTrigger && (Time.time - lastCheck) >= checkInterval)
        {
            target = col.gameObject.transform;
            Shoot(col);
            lastCheck = Time.time;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            inTrigger = false;
        }
    }
    void Shoot(Collider col)
    {
        Debug.Log("Enemy detected!");
        GameObject g = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        g.GetComponent<Cannonball>().target = col.gameObject.transform.position;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
