using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class moveMeanScript : MonoBehaviour
{
    public Image mean, median, legend;
    public GameObject bar;
    //public GameObject legend;

    bool fullscreen;

    public Vector3 meanPos, meanFullPos, medianPos, medianFullPos, legendPos, legendFullPos;
    public Vector2 meanSize, meanFullSize, medianSize, medianFullSize, legendSize, legendFullSize;

    public bool hasMedian;
    // Start is called before the first frame update
    void Start()
    {

        //GetPositionOnGraph();
        Run();
    }

    public void GetPositionOnGraph()
    {
        var barChart = bar.GetComponent<BarChart>();

        Vector3 bottomPosition;
        if (barChart.GetBarTrackPosition("Group 1", "Player 1", out bottomPosition))
        {
            meanPos = bottomPosition;
            meanFullPos = bottomPosition;

            Debug.Log("Top Position: " + bottomPosition);
            //topPosition now contains the top position of the bar
        }
        else
        {
            Debug.Log("NOPE");
        }
    }

    public void Run()
    {
        var barChart = bar.GetComponent<BarChart>();

        barChart.DataSource.StartBatch();
        barChart.DataSource.ClearValues();

        int[] barValues;
        barValues = new int[10];


        for (int i = 0; i < barValues.Length; i++)
        {
            barValues[i] = UnityEngine.Random.Range(1, 30);

            string categoryName = (2011 + i).ToString();
            barChart.DataSource.SetValue(categoryName, "Values", barValues[i]);

           /* float animationTime = 1.0f; // one second;
            barChart.DataSource.SlideValue(categoryName, "Values", barValues[i], animationTime);*/
        }

        barChart.DataSource.EndBatch();
        meanCalculate(barValues);
    }
    public void meanCalculate(int[] values)
    {
        var barChart = bar.GetComponent<BarChart>();

        float mean = 0;
        int sum = 0;

        for (int x = 0; x < values.Length; x++)
        //sums up all the values
        {
            Debug.Log("value " + x.ToString() + ": " + values[x]);
            sum += values[x];
        }

        mean = sum / values.Length;
        Debug.Log("mean: " + mean);
        //calculates the mean

        var nearest = values.Aggregate((current, next) => Math.Abs((long)current - mean) < Math.Abs((long)next - mean) ? current : next);
        //Debug.Log("nearest: " + nearest);
        int index = Array.IndexOf(values, nearest);
        //Debug.Log("Index: " + index);
        string indexCategory = (2011+index).ToString();
        //Debug.Log("Index Category: " + indexCategory);
        //finds the closest value in the array to the mean at that index
        
        Vector3 bottomPosition;

        //Debug.Log(barChart.DataSource.GetCategoryName(index));
       // Debug.Log(barChart.DataSource.GetGroupName(0));

       // Debug.Log(barChart.GetBarTrackPosition(barChart.DataSource.GetCategoryName(index), barChart.DataSource.GetGroupName(0), out bottomPosition));


       /* if (bar.GetBarBottomPosition(indexCategory, "Values", out bottomPosition))
        {
            meanPos = bottomPosition;
            meanFullPos = bottomPosition;

            Debug.Log("Top Position: " + bottomPosition);
            //topPosition now contains the top position of the bar
        }
        else
        {
            Debug.Log("FAILED, category at index:" + bar.DataSource.GetCategoryName(index) + " ");
        }*/



    }


    public void Fullscreen()
    {
        if (!fullscreen)
        {
            fullscreen = true;
            mean.rectTransform.anchoredPosition = meanFullPos;
            mean.rectTransform.sizeDelta = meanFullSize;

            if (hasMedian)
            {
                median.rectTransform.anchoredPosition = medianFullPos;
                median.rectTransform.sizeDelta = medianFullSize;
            }

            legend.rectTransform.anchoredPosition = legendFullPos;
            legend.rectTransform.sizeDelta = legendFullSize;

            Debug.Log("Fullscreen");
        }
        else
        {
            fullscreen = false;
            mean.rectTransform.anchoredPosition = meanPos;
            mean.rectTransform.sizeDelta = meanSize;


            if (hasMedian)
            {
                median.rectTransform.anchoredPosition = medianPos;
                median.rectTransform.sizeDelta = medianSize;
            }

            legend.rectTransform.anchoredPosition = legendPos;
            legend.rectTransform.sizeDelta = legendSize;
            Debug.Log("not Fullscreen");
        }
        //mean.offsetMin = new Vector2(50, 70); //left, bottom
        //mean.offsetMax = new Vector2(-50, -50); //-right, -top
    }
}
