using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] public float speed = 100.0f;
    [SerializeField] private GameObject rotatorObject;
    [SerializeField] private Transform rTransform;

    private void Update()
    {
        SetRotate();
    }

    public void SetRotate() 
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
