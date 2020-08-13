using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnBlank : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] objects;

    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].gameObject.SetActive(false);
        }
    }

    public void turnOn()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].gameObject.SetActive(true);
        }
    }

    public void turnOff()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].gameObject.SetActive(false);
        }
    }
}
