using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChartAndGraph;

public class BarPlotHorizontalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform canvas;

    public BarChart chart;

    public RandomFromDistribution.ConfidenceLevel_e conf_level = RandomFromDistribution.ConfidenceLevel_e._95;
    public Slider heightSlider;
    public float noiseValue;
    public float slope, yIntercept;
    public float[] sliderValue, noise;

    bool fullscreen;

    void Start()
    {
        Simulate();
        //chart = GetComponent<BarChart>();
    }

    void Update()
    {
        chart = GetComponentInChildren<BarChart>();
    }

    public void Simulate()
    {
        //Debug.Log("SIMULATE");
        //chart = GetComponent<BarChart>();
        chart.DataSource.StartBatch();
        chart.DataSource.ClearValues();
        slope = heightSlider.value;

        if (chart != null)
        {
            for (int i = 0; i < 10; i++)
            {
                //chart.DataSource.ClearValues();
                chart.DataSource.SetValue(i + 1 + "yr", "All", 2);

                noise[i] = RandomFromDistribution.RandomRangeNormalDistribution(-noiseValue, noiseValue, conf_level);

                sliderValue[i] = (slope * i) + yIntercept;

                if (i == 0)
                {
                    chart.DataSource.SetValue(i + 1 + "yr", "All", sliderValue[i] + noise[i]);
                    //chart.DataSource.SetCurveInitialPoint("Player 2", 0, sliderValue[i] + noise[i]); //+ heightSlider.value / 4
                }
                else if (i == 10)
                {
                    chart.DataSource.SetValue(i + 1 + "yr", "All", sliderValue[i]);
                }
                if (i != 0)
                {
                    sliderValue[i] += noise[i - 1] + noise[i];
                }

                chart.DataSource.SetValue(i + 1 + "yr", "All", sliderValue[i]);
            }
        }
        chart.DataSource.EndBatch();
    }

    public void setFullscreen()
    {
        if (fullscreen)
        {
            canvas.offsetMin = new Vector2(50, 40); //left, bottom
            canvas.offsetMax = new Vector2(-50, -40); //-right, -top

            // canvas = GetComponent<RectTransform>(); //left, bottom
            // canvas.localScale = new Vector3(1, 1, 1);

            fullscreen = false;
        }
        else
        {
            canvas.offsetMin = new Vector2(50, 80);
            canvas.offsetMax = new Vector2(-50, -80);

            //canvas = GetComponent<RectTransform>(); //left, bottom
            //canvas.localScale = new Vector3(2, 2, 1);

            fullscreen = true;
        }
    }
}
