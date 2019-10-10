using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public GameObject water;
    public GameObject slider;
    bool isMoving = false;
    bool isIncreasing = true;
    public float minimum = -4.0F;
    public float maximum = -2.0F;
    float lastValue;
    int initialValue = 0;
    int temp;

    static float t = 0.0f;

    void Start()
    {
        lastValue = (int)slider.gameObject.GetComponent<Slider>().value;
    }

    void Update()
    {
        //Debug.Log((int)slider.gameObject.GetComponent<Slider>().value);
        if (isMoving)
        {
            water.gameObject.transform.position = new Vector3(0, Mathf.Lerp(minimum, maximum, t), 0);
            t += 0.5f * Time.deltaTime;
            if (t >= 1.0f)
            {
                isMoving = false;
                t = 0.0f;
            }
        }
    }

    public void setSliderValue()
    {
        if ((int)slider.gameObject.GetComponent<Slider>().value < lastValue)
        {
            Debug.Log("Decreased!");
            isIncreasing = false;
            lastValue = (int)slider.gameObject.GetComponent<Slider>().value;
        }
        else if ((int)slider.gameObject.GetComponent<Slider>().value > lastValue)
        {
            Debug.Log("Increased!");
            isIncreasing = true;
            lastValue = (int)slider.gameObject.GetComponent<Slider>().value;
        }

        Debug.Log(isIncreasing);

        if (slider.gameObject.GetComponent<Slider>().value == 0 && isIncreasing)
        {
            minimum = -2.0f;
            maximum = -2.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 1 && isIncreasing)
        {
            minimum = -2.0f;
            maximum = -1.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 2 && isIncreasing)
        {
            minimum = -1.0f;
            maximum = 0.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 3 && isIncreasing)
        {
            minimum = 0.0f;
            maximum = 1.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 0 && !isIncreasing)
        {
            minimum = -1.0f;
            maximum = -2.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 1 && !isIncreasing)
        {
            minimum = 0.0f;
            maximum = -1.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 2 && !isIncreasing)
        {
            minimum = 1.0f;
            maximum = 0.0f;
            isMoving = true;
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 3 && !isIncreasing)
        {
            minimum = 1.0f;
            maximum = 0.0f;
            isMoving = true;
        }
    }
}
