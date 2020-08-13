using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FloatScript : MonoBehaviour
{
    public GameObject water;
    public float waterLevel = 1f;
    public float waterOffset;
    public float floatHeight = 2f;
    public float bounceDamp = 0.5f;
    public bool isKinematic = false; 
    public Vector3 bouyancyCenterOffset;

    float forceFactor;
    Vector3 actionPoint;
    Vector3 upLift;

    void Start()
    {
        if (isKinematic)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

        int rotDirection = (int)Random.Range(0, 2);

        if (rotDirection == 0)
        {
            bouyancyCenterOffset.x = 0;
            bouyancyCenterOffset.y = Random.Range(.5f, 1);
            bouyancyCenterOffset.z = Random.Range(.5f, 1);
        }
        else if (rotDirection == 1)
        {
            bouyancyCenterOffset.x = Random.Range(.5f, 1);
            bouyancyCenterOffset.y = 0;
            bouyancyCenterOffset.z = Random.Range(.5f, 1);
        }
        else
        {
            bouyancyCenterOffset.x = Random.Range(.5f, 1);
            bouyancyCenterOffset.y = Random.Range(.5f, 1);
            bouyancyCenterOffset.z = 0;
        }
    }

    void Update()
    {
        waterLevel = water.transform.position.y + waterOffset;
        actionPoint = transform.position + transform.TransformDirection(bouyancyCenterOffset);
        forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0f)
        {
            upLift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * bounceDamp) * GetComponent<Rigidbody>().mass;
            GetComponent<Rigidbody>().AddForceAtPosition(upLift, actionPoint);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Water")
        {
            //Debug.Log("I TOUCHED IT");

            if (isKinematic)
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
