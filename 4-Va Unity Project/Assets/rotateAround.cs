using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    // Update is called once per frame
    public float rotateSpeed;
    public Transform target;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
