using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // public GameObject objToDestroy;
 
 
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Enemy")
    //         Destroy(objToDestroy);
 
    // }

    void OnTriggerEnter(Collider otherObj)
    {
        var enemy = GameObject.FindWithTag("Enemy");
        
        if (otherObj.gameObject.tag == "Enemy") {
            Destroy (enemy);
        }
    }
}
