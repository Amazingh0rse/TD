using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float speed = 40;
    public float range = 15f;

    //Target (Set by tower)
    public Vector3 target;

    void FixedUpdate()
    {
        //Check if target exists
        if (target != null)
        {
            //Fly towards target
            Vector3 direction = target - transform.position;
            GetComponent<Rigidbody>().velocity = direction.normalized * speed;
            Destroy(gameObject, 5f);
        }
        else
        {
            //if target is gone, destroy self
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider co)
    {
        //Destroy prefab if it hits an enemy, but allow to collide with tower and other canonballs
        if (co.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (co.tag != "tower" && co.tag != "canonball")
        {
            Destroy(gameObject);
        }
    }
}
