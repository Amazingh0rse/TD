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

    void Start()
    {
        audioComp = GetComponent<AudioSource>();
        audioComp.playOnAwake = false;
        audioComp.clip = fireSound;
        audioComp.volume = fireSoundVolume;
    }

    void OnTriggerStay(Collider col)
    {
        inTrigger = true;
        if (col.tag == "Enemy" && inTrigger && (Time.time - lastCheck) >= checkInterval)
        {
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
}
