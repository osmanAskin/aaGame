using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pinPrefab;

    internal bool isContinuous = true;

    private void Update()
    {
        if (isContinuous) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SpawnPinPrefab();
            }
        }
    }

    private void SpawnPinPrefab() 
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}
