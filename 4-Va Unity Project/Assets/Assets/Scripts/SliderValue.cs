using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class SliderValue : MonoBehaviour
{
    string sliderVal;

    public GameObject valueText1;
    public GameObject valueText2;

    public GameObject grid1;
    public GameObject grid2;
    public GameObject grid3;
    public GameObject grid4;


    public string GetSliderValue()
    {
        //Debug.Log(slider.gameObject.GetComponent<Slider>().value);
        //Text sliderText = slider.gameObject.GetComponent<Text>();
        //string sliderString = sliderText.ToString();

        //sliderString = slider.gameObject.GetComponent<Slider>().value.ToString();

        //slider.gameObject.GetComponent<Slider>().GetComponent<Text>().text = slider.gameObject.GetComponent<Slider>().value.ToString();
        //sliderVal = slider.gameObject.GetComponent<Slider>().value.ToString();

        Debug.Log("get"+sliderVal);

        return sliderVal;
    }

    public void SetSliderValue(GameObject slider)
    {
        //this.sliderVal= slider.gameObject.GetComponent<Slider>().value.ToString();
        //sliderVal = slider.gameObject.GetComponent<Slider>().value.ToString();
        if (slider.CompareTag("eCam"))
        {
            valueText1.gameObject.GetComponent<Text>().GetComponent<Text>().text = slider.gameObject.GetComponent<Slider>().value.ToString();
        }
        else
        {
            valueText2.gameObject.GetComponent<Text>().GetComponent<Text>().text = slider.gameObject.GetComponent<Slider>().value.ToString();
        }

        if (slider.gameObject.GetComponent<Slider>().value == 0)
        {
            grid1.SetActive(true);
            grid2.SetActive(false);
            grid3.SetActive(false);
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 1)
        {
            grid1.SetActive(false);
            grid2.SetActive(true);
            grid3.SetActive(false);
        }
        else if (slider.gameObject.GetComponent<Slider>().value == 2)
        {
            grid1.SetActive(false);
            grid2.SetActive(false);
            grid3.SetActive(true);
            grid4.SetActive(false);
        }
        else if(slider.gameObject.GetComponent<Slider>().value == 3)
        {
            grid1.SetActive(false);
            grid2.SetActive(false);
            grid3.SetActive(true);
            grid4.SetActive(true);
        }
        else
        {
            grid1.SetActive(false);
            grid2.SetActive(false);
            grid3.SetActive(true);
        }
    }

    public void ShowSliderValue(GameObject valueText)
    {
        //Debug.Log(slider.gameObject.GetComponent<Slider>().value);
        //Text sliderText = slider.gameObject.GetComponent<Text>();
        //string sliderString = sliderText.ToString();

        //sliderString = slider.gameObject.GetComponent<Slider>().value.ToString();

        string valueString = valueText.ToString();
        valueString = sliderVal;
    }
}
