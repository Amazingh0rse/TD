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
        //Initialize audio
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
        //Get the direction to the target
        Vector3 direction = target.transform.position - transform.position;
        //Determine the rotation towards the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        //Prepare the direction and speed for rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //Rotate the model
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void OnTriggerStay(Collider col)
    {
        //Check if there's a gameobject with tag "Enemy" within the trigger.
        //Then check when a cannonball was last fired before firing again.
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
        //Instantiate a cannonball and play fire sound
        GameObject cannonball = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        //Cannonball prefab has a target in component and uses collision data to set current target.
        cannonball.GetComponent<Cannonball>().target = col.gameObject.transform.position;
    }

    //Draw a range gizmo for the towers trigger in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
