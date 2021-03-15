using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Referenace to the ingame camera
    public Transform cam;

    // LateUpdate is called after Update()
    // The good thing here is the camera does all it's movement and then I point towards it
    // This should stop jitters ingame
    void LateUpdate()
    {
       transform.LookAt(transform.position + cam.forward); 
    }
}
