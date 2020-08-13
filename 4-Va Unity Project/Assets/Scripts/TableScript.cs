using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ColumnRowObject;
    public RectTransform table;
    public GameObject[] rowObjects;

    public RandomFromDistribution.ConfidenceLevel_e conf_level = RandomFromDistribution.ConfidenceLevel_e._95;
    public Slider heightSlider;
    public float noiseValue;
    public float slope, yIntercept;
    public float[] sliderValue, noise;

    bool fullscreen;

    void Start()
    {
        for (int i = 0; i < rowObjects.Length; i++)
        {
            rowObjects[i].gameObject.SetActive(false);
        }
    }

    public void Simulate()
    {
        for (int i = 0; i < rowObjects.Length; i++)
        {
            rowObjects[i].gameObject.SetActive(true);
        }

        slope = heightSlider.value;

        for (int i = 0; i < rowObjects.Length; i++)
        {
            noise[i] = RandomFromDistribution.RandomRangeNormalDistribution(-noiseValue, noiseValue, conf_level);
            sliderValue[i] = (slope * i) + yIntercept;

            if (i == 0)
            {
                sliderValue[i] += noise[i];
            }
            else
            {
                sliderValue[i] += noise[i - 1] + noise[i];
            }

            rowObjects[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (i+1).ToString() + "yr";
            rowObjects[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (Mathf.Round(sliderValue[i] * 100f)/100f).ToString() + "m";
        }
    }

    public void setFullscreen()
    {
        //if (fullscreen)
        //{
        //    table = GetComponent<RectTransform>(); //left, bottom
        //    table.localScale = new Vector3(1, 1, 1);
        //    fullscreen = false;
        //}
        //else
        //{
        //    table = GetComponent<RectTransform>(); //left, bottom
        //    table.localScale = new Vector3(2, 2, 1);
        //    fullscreen = true;
        //}
    }
}
