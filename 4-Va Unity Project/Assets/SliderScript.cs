using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public GameObject water;

    void Start()
    {
        
    }

    public void setSliderValue(GameObject slider)
    {
        water.gameObject.transform.position = new Vector3(0, slider.gameObject.GetComponent<Slider>().value, 0);
    }
}
