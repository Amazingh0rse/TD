using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //This class is just to have a namespace to refer to
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "canonball")
        {
            //Debug.Log("Ouch! I was hit");
        }
    }
}
