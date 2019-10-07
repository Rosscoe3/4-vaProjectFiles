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
        if (slider.gameObject.GetComponent<Slider>().value == 0)
        {
            water.gameObject.transform.position = new Vector3(0, -2f, 0);
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 1)
        {
            water.gameObject.transform.position = new Vector3(0, -1f, 0);
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 2)
        {
            water.gameObject.transform.position = new Vector3(0, 0, 0);
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 3)
        {
            water.gameObject.transform.position = new Vector3(0, 1, 0);
        }
    }
}
