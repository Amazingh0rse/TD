using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{

    [SerializeField] private GameObject towerPrefab;
    Vector3 offset = new Vector3(0f,1f,0f);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Instantiate(towerPrefab, hit.point - offset, Quaternion.identity);
            }
        }
    }
}
