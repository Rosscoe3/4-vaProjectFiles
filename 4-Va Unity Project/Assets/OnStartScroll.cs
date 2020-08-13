using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartScroll : MonoBehaviour
{
    Scrollbar scroll; 

    void Awake()
    {
        scroll = gameObject.GetComponent<Scrollbar>();
        scroll.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //scroll.value = 1f;
    }
}
