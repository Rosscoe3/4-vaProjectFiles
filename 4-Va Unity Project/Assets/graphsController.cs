using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChartAndGraph;
using System.Linq;

public class graphsController : MonoBehaviour
{
    public RandomFromDistribution.ConfidenceLevel_e conf_level = RandomFromDistribution.ConfidenceLevel_e._95;
    public Slider heightSlider;
    public float noiseValue;
    public float slope, yIntercept;
    public float[] sliderValue, noise;

    public float[] histogramRanges;

    public RectTransform barVertCanvas;
    public BarChart barVertChart;

    public RectTransform barHorzCanvas;
    public BarChart barHorzChart;

    public RectTransform stackedBarCanvas;
    public BarChart stackedBarChart;

    public RectTransform histogramBarCanvas;
    public BarChart histogramBarChart;
    public ChartDynamicMaterial[] categoryStyles;

    public RectTransform pieChartCanvas;
    public PieChart pieChartChart;

    public RectTransform timeSeriesCanvas;
    public GraphChart timeseriesChart;

    public RectTransform scatterPlotCanvas;
    public GraphChart scatterPlotChart;

    public RectTransform boxPlotCanvas;
    public CandleChart boxPlotChart;

    public RectTransform boxPlotHorzCanvas;
    public CandleChart boxPlotHorzChart;

    public RectTransform sideBySideBoxPlotCanvas;
    public CandleChart sideBySideBoxPlotChart;

    public GameObject ColumnRowObject;
    //public GameObject tableHilighter;
    public RectTransform table;
    public GameObject[] rowObjects;
    public string[] mslValues;
    public string[] floodingDamageValues;
    public string[] averageAnnualHighTemperatureValues;

    public Scrollbar pg3Scroll, pg4Scroll, pg5Scroll;

    bool fullscreen;
    bool animateVBar,animateHBar, animateSBar;


    int lowestRanges, lowRanges, midRanges, highRanges, highestRanges;

    public GameObject tableGraph, chap1Graph, verticalBarPlottGraph, horizontalBarPlotGraph, stackedBarPlotGraph,
        histogramGraph, pieChartGraph, timeSeriesGraph, timeSeriesText, scatterPlotGraph, scatterPlotText, boxPlotGraph, boxPlotHorzGraph, sideBySideBoxPlotGraph;

    void Awake()
    {
        Simulate();
    }

    void Start()
    {
        tableGraph.SetActive(true);
        chap1Graph.SetActive(false);
        verticalBarPlottGraph.SetActive(false);
        horizontalBarPlotGraph.SetActive(false);
        stackedBarPlotGraph.SetActive(false);
        histogramGraph.SetActive(false);
        pieChartGraph.SetActive(false);
        timeSeriesGraph.SetActive(false);
        timeSeriesText.SetActive(false);
        scatterPlotText.SetActive(false);
        scatterPlotGraph.SetActive(false);
        boxPlotGraph.SetActive(false);
        boxPlotHorzGraph.SetActive(false);
        sideBySideBoxPlotGraph.SetActive(false);

        animateVBar = true;

        for (int i = 0; i < rowObjects.Length; i++)
        {
            rowObjects[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        barVertChart = verticalBarPlottGraph.GetComponentInChildren<BarChart>();
        barHorzChart = horizontalBarPlotGraph.GetComponentInChildren<BarChart>();
        stackedBarChart = stackedBarPlotGraph.GetComponentInChildren<BarChart>();
        histogramBarChart = histogramGraph.GetComponentInChildren<BarChart>();
        pieChartChart = pieChartGraph.GetComponentInChildren<PieChart>();
        timeseriesChart = timeSeriesGraph.GetComponentInChildren<GraphChart>();
        scatterPlotChart = scatterPlotGraph.GetComponentInChildren<GraphChart>();
        boxPlotChart = boxPlotGraph.GetComponentInChildren<CandleChart>();
        boxPlotHorzChart = boxPlotHorzGraph.GetComponentInChildren<CandleChart>();
        sideBySideBoxPlotChart = sideBySideBoxPlotGraph.GetComponentInChildren<CandleChart>();
    }

    public void turnGraphOn(string graphName)
    {
        if (graphName == "table")
        {
            tableGraph.SetActive(true);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "chap1")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(true);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "vBarPlot")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(true);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "hBarPlot")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(true);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "sBarPlot")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(true);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "histogram")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(true);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "pieChart")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(true);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "timeseries")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(true);
            timeSeriesText.SetActive(true);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "scatter")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(true);
            scatterPlotGraph.SetActive(true);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "boxPlot")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(true);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(true);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "boxPlotHorz")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(true);
            sideBySideBoxPlotGraph.SetActive(false);
        }
        if (graphName == "sideBySideBoxPlot")
        {
            tableGraph.SetActive(false);
            chap1Graph.SetActive(false);
            verticalBarPlottGraph.SetActive(false);
            horizontalBarPlotGraph.SetActive(false);
            stackedBarPlotGraph.SetActive(false);
            histogramGraph.SetActive(false);
            pieChartGraph.SetActive(false);
            timeSeriesGraph.SetActive(false);
            timeSeriesText.SetActive(false);
            scatterPlotText.SetActive(false);
            scatterPlotGraph.SetActive(false);
            boxPlotGraph.SetActive(false);
            boxPlotHorzGraph.SetActive(false);
            sideBySideBoxPlotGraph.SetActive(true);
        }
    }

    public void Simulate()
    {
        slope = heightSlider.value;

        for (int i = 0; i < 50; i++)
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
        }

        if (tableGraph.activeSelf)
        {
            tableSimulate();
        }
        else if (verticalBarPlottGraph.activeSelf)
        {
            barVertSimulate();
        }
        else if (horizontalBarPlotGraph.activeSelf)
        {
            barHorzSimulate();
        }
    }

    public void tableSimulate()
    {
        for (int i = 0; i < rowObjects.Length; i++)
        {
            rowObjects[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < 50; i++) //rowObjects.Length
        {
            //Chooses the years for the text
            rowObjects[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (i + 1 + 1970).ToString();

            //Goes through the height slider value of the simulation
            //rowObjects[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (Mathf.Round(sliderValue[i] * 100f) / 100f).ToString() + "ft";
            rowObjects[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = mslValues[i].ToString();

            //Values for Flooding Damage
            rowObjects[i].transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = floodingDamageValues[i].ToString();

            //Values for Average annual high temperature
            rowObjects[i].transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = averageAnnualHighTemperatureValues[i].ToString();

        }
    }

    public void barVertSimulate()
    {
        barVertChart.DataSource.StartBatch();
        barVertChart.DataSource.ClearValues();

        if (barVertChart != null)
        {
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    barVertChart.DataSource.SetValue((i + 2000).ToString(), "Vertical Bar Plot", sliderValue[i] + noise[i]);
                }
                else if (i == 10)
                {
                    barVertChart.DataSource.SetValue((i + 2000).ToString(), "Vertical Bar Plot", sliderValue[i]);
                }

                barVertChart.DataSource.SetValue((i + 2000).ToString(), "Vertical Bar Plot", sliderValue[i]);
            }
        }
        barVertChart.DataSource.EndBatch();
    }

    public void barHorzSimulate()
    {
        barHorzChart.DataSource.StartBatch();
        barHorzChart.DataSource.ClearValues();

        if (barHorzChart != null)
        {
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    barHorzChart.DataSource.SetValue((i + 2000).ToString(), "Horizontal Bar Plot", sliderValue[i] + noise[i]);
                }
                else if (i == 10)
                {
                    barHorzChart.DataSource.SetValue((i + 2000).ToString(), "Horizontal Bar Plot", sliderValue[i]);
                }

                barHorzChart.DataSource.SetValue((i + 2000).ToString(), "Horizontal Bar Plot", sliderValue[i]);
            }
        }
        barHorzChart.DataSource.EndBatch();
    }

    public void barStackedSimulate()
    {
        stackedBarChart.DataSource.StartBatch();
        stackedBarChart.DataSource.ClearValues();

        int stayedNum = (int)UnityEngine.Random.Range(90, 100);
        int leftNumb = 100 - stayedNum;

        Debug.Log("1 left number: " + leftNumb);
        Debug.Log("1 stayed number: " + stayedNum);

        Debug.Log(stackedBarChart != null);

        if (stackedBarChart != null)
        {
            for (int i = 1970; i < 2021; i+=5)
            {
                if (i > 1)
                {
                    //leftNumb = (int)UnityEngine.Random.Range(stayedNum / 2, stayedNum);
                    //stayedNum = stayedNum - leftNumb;

                    //stayedNum = (int)UnityEngine.Random.Range((stayedNum / 2), stayedNum);
                    //leftNumb = stayedNum - leftNumb;

                    //leftNumb = (int)UnityEngine.Random.Range(stayedNum / 4, stayedNum);
                    //stayedNum -= 100;

                    int rnd;

                    if (stayedNum > 60)
                    {
                        rnd = (int)UnityEngine.Random.Range(0, 10);
                    }
                    else
                    {
                        rnd = (int)UnityEngine.Random.Range(0, 3);
                    }

                    leftNumb = leftNumb + rnd;
                    stayedNum = 100 - leftNumb; 

                    Debug.Log(i + " left number: " + leftNumb);
                    Debug.Log(i + " stayed number: " + stayedNum);
                }

                if (leftNumb < stayedNum)
                {
                    stackedBarChart.DataSource.SetValue("Left", i.ToString(), leftNumb);
                    stackedBarChart.DataSource.SetValue("Stayed", i.ToString(), stayedNum);
                }
                else if (stayedNum < leftNumb)
                {
                    stackedBarChart.DataSource.SetValue("Stayed", i.ToString(), stayedNum);
                    stackedBarChart.DataSource.SetValue("Left", i.ToString(), leftNumb);
                }
            }
        }
        stackedBarChart.DataSource.EndBatch();
    }

    public void histogramSimulate()
    {
        float[] ranges = new float[6];
        float lowestNumb, highestNumb, rangeVal, interval;

        lowestNumb = Mathf.Min(sliderValue);
        highestNumb = Mathf.Max(sliderValue);

        //Debug.Log(Mathf.Abs(lowestNumb));

        rangeVal = highestNumb - Mathf.Abs(lowestNumb);
        interval = rangeVal / 5;

        lowestRanges = 0;
        lowRanges = 0;
        midRanges = 0;
        highRanges = 0;
        highestRanges = 0;

        //Debug.Log("lowest: " + lowestNumb);
        //Debug.Log("highest: " + highestNumb);
        //Debug.Log("range value: " + rangeVal);
        //Debug.Log("interval: " + interval);

        for (int i = 1; i < ranges.Length; i++)
        {
            ranges[i] = interval * i;
        }

        for (int ii = 0; ii < sliderValue.Length; ii++)
        {
            if (sliderValue[ii] >= lowestNumb && sliderValue[ii] <= ranges[1])
            {
                lowestRanges++;
            }
            if (sliderValue[ii] > ranges[1] && sliderValue[ii] <= ranges[2])
            {
                lowRanges++;
            }
            if (sliderValue[ii] > ranges[2] && sliderValue[ii] <= ranges[3])
            {
                midRanges++;
            }
            if (sliderValue[ii] > ranges[3] && sliderValue[ii] <= ranges[4])
            {
                highRanges++;
            }
            if (sliderValue[ii] > ranges[4] && sliderValue[ii] <= highestNumb)
            {
                highestRanges++;
            }
        }

        //Debug.Log("numb of Lowest Ranges: " + lowestRanges);
        //Debug.Log("numb of Low Ranges: " + lowRanges);
        //Debug.Log("numb of Mid Ranges: " + midRanges);
        //Debug.Log("numb of High Ranges: " + highRanges);
        //Debug.Log("numb of Highest Ranges: " + highestRanges);
        //Debug.Log("Range one: " + ranges[1]);

       
        histogramBarChart.DataSource.StartBatch();
        histogramBarChart.DataSource.ClearCategories();
        histogramBarChart.DataSource.ClearValues();

        for (int i = 1; i < 6; i++)
        {
            histogramBarChart.DataSource.AddCategory("Player " + i, categoryStyles[i]);
        }

        if (histogramBarChart != null)
        {
            histogramBarChart.DataSource.SetValue("Player " + 1, "Histogram", lowestRanges);
            histogramBarChart.DataSource.SetValue("Player " + 2, "Histogram", lowRanges);
            histogramBarChart.DataSource.SetValue("Player " + 3, "Histogram", midRanges);
            histogramBarChart.DataSource.SetValue("Player " + 4, "Histogram", highRanges);
            histogramBarChart.DataSource.SetValue("Player " + 5, "Histogram", highestRanges);

            for (int i = 1; i < 6; i++)
            {
                if (i == 1)
                {
                    histogramBarChart.DataSource.RenameCategory("Player " + i, (Mathf.Round(lowestNumb * 100)) / 100 + " - " + (Mathf.Round(ranges[i] * 100)) / 100);
                }
                else if (i != 1 && i != 5)
                {
                    histogramBarChart.DataSource.RenameCategory("Player " + i, (Mathf.Round(ranges[i-1] * 100)) / 100 + .01f + " - " + (Mathf.Round(ranges[i] * 100)) / 100);
                }
                else if (i == 5)
                {
                    histogramBarChart.DataSource.RenameCategory("Player " + i, (Mathf.Round(ranges[4] * 100)) / 100 + .01f + " - " + (Mathf.Round(highestNumb * 100)) / 100);
                }
            }
        }
        histogramBarChart.DataSource.EndBatch();
    }

    public void pieChartSimulate()
    {
        pieChartChart.DataSource.StartBatch();

        if (pieChartGraph != null)
        {
            int stayed = (int)UnityEngine.Random.Range(0, 100);
            int left = 100 - stayed;

            pieChartChart.DataSource.SetValue("Stayed", stayed);
            pieChartChart.DataSource.SetValue("Left", left);
        }

        pieChartChart.DataSource.EndBatch();
    }

    public void timeseriesSimulate()
    {
        if (timeseriesChart != null)
        {
            timeseriesChart.DataSource.StartBatch();  // start a new update batch
            timeseriesChart.DataSource.ClearCategory("Player 1");  // clear the categories we have created in the inspector
            timeseriesChart.DataSource.ClearCategory("Player 3");
            timeseriesChart.DataSource.ClearAndMakeBezierCurve("Player 2");

            for (int i = 0; i < 50; i++)
            {
                if (i == 0)
                {
                    timeseriesChart.DataSource.SetCurveInitialPoint("Player 2", 0, sliderValue[i]); //+ heightSlider.value / 4
                }
                else if (i == 49)
                {
                    timeseriesChart.DataSource.AddLinearCurveToCategory("Player 2", new DoubleVector2(i, sliderValue[i]));
                }

                //add 50 random points , each with a category and an x,y value
                timeseriesChart.DataSource.AddPointToCategory("Player 1", i, sliderValue[i]);
                //graph.DataSource.AddLinearCurveToCategory("Player 2", new DoubleVector2(i, sliderValue));
            }
            timeseriesChart.DataSource.MakeCurveCategorySmooth("Player 2");
            timeseriesChart.DataSource.EndBatch(); // end the update batch . this call will render the graph
        }
    }

    public void scatterPlotSimulate()
    {
        if (scatterPlotChart != null)
        {
            scatterPlotChart.DataSource.StartBatch();  // start a new update batch
            scatterPlotChart.DataSource.ClearCategory("Player 1");  // clear the categories we have created in the inspector

            for (int i = 0; i < 50; i++)
            {
                //add 50 random points , each with a category and an x,y value
                scatterPlotChart.DataSource.AddPointToCategory("Player 1", i, sliderValue[i]);
                //graph.DataSource.AddLinearCurveToCategory("Player 2", new DoubleVector2(i, sliderValue));
            }
            scatterPlotChart.DataSource.EndBatch(); // end the update batch . this call will render the graph
        }
    }

    public void boxPlotSimulate()
    {
        //boxPlotChart = GetComponent<CandleChart>();
        if (boxPlotChart != null)
        {
            //sliderValue.OrderBy(score => score);

            boxPlotChart.DataSource.StartBatch();
            boxPlotChart.DataSource.ClearCategory("Player 1");

            int count = 0;
            float median, quarter, thirdQuarter; 
            float[] sortArray = new float[50];

            foreach (float sort in sliderValue.OrderBy(sorted => sorted))
            {
                //Debug.Log(sort);
                sortArray[count] = sort;
                count++;
            }

            median = (sortArray[24] + sortArray[25]) / 2;
            quarter = sortArray[12];
            thirdQuarter = sortArray[37];


            /// the values are in the follwing order: open high low close, start time , time durtaion
            // bottom point of box, top line end, bottom line end, top point of box, xPos 
            boxPlotChart.DataSource.AddCandleToCategory("Player 1", new CandleChartData.CandleValue(quarter, sortArray[49],
                sortArray[0], thirdQuarter, 5f, Random.value * 10f / 30f));

            boxPlotChart.DataSource.EndBatch();
        }

        //if (boxPlotChart != null)
        //{
        //    boxPlotChart.DataSource.StartBatch();
        //    boxPlotChart.DataSource.ClearCategory("Player 1");
        //    for (int x = 0; x < 10; x++)
        //    {
        //        for (int i = 0; i < 50; i++)
        //        {
        //            noise[i] = RandomFromDistribution.RandomRangeNormalDistribution(-noiseValue, noiseValue, conf_level);
        //            sliderValue[i] = (slope * i) + yIntercept;

        //            if (i != 0)
        //            {
        //                sliderValue[i] += noise[i - 1] + noise[i];
        //            }
        //        }
        //        // boxPlotChart.DataSource.AddPointToCategory("Player 3", args.Value.x, sliderValue[(int)args.Value.x]);
        //        boxPlotChart.DataSource.AddCandleToCategory("Player 1", new CandleChartData.CandleValue(5f, Random.Range(10f, 15f),
        //             2f, Random.Range(5f, 10f), 5f, Random.value * 10f / 30f));
        //    }
        //    boxPlotChart.DataSource.EndBatch();
        //}
    }

    public void boxPlotHorizontalSimulate()
    {
        //boxPlotHorzChart.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (boxPlotHorzChart != null)
        {
            //sliderValue.OrderBy(score => score);

            boxPlotHorzChart.DataSource.StartBatch();
            boxPlotHorzChart.DataSource.ClearCategory("Player 1");

            int count = 0;
            float median, quarter, thirdQuarter;
            float[] sortArray = new float[50];

            foreach (float sort in sliderValue.OrderBy(sorted => sorted))
            {
                //Debug.Log(sort);
                sortArray[count] = sort;
                count++;
            }

            median = (sortArray[24] + sortArray[25]) / 2;
            quarter = sortArray[12];
            thirdQuarter = sortArray[37];


            /// the values are in the follwing order: open high low close, start time , time durtaion
            // bottom point of box, top line end, bottom line end, top point of box, xPos 
            boxPlotHorzChart.DataSource.AddCandleToCategory("Player 1", new CandleChartData.CandleValue(quarter, sortArray[49],
                sortArray[0], thirdQuarter, 5f, Random.value * 10f / 30f));

            boxPlotHorzChart.DataSource.EndBatch();
        }
        //boxPlotHorzChart.transform.localRotation = Quaternion.Euler(0, 0, -90);
    }

    public void sideBySideBoxPlotSimulate()
    {
        //boxPlotChart = GetComponent<CandleChart>();
        if (sideBySideBoxPlotChart != null)
        {
            //sliderValue.OrderBy(score => score);

            sideBySideBoxPlotChart.DataSource.StartBatch();
            sideBySideBoxPlotChart.DataSource.ClearCategory("Player 1");
            sideBySideBoxPlotChart.DataSource.ClearCategory("Player 2");

            int count = 0;
            int count2 = 0;
            float median, quarter, thirdQuarter;
            float median2, quarter2, thirdQuarter2;
            float[] sortArray = new float[50];
            float[] sortArray2 = new float[50];

            foreach (float sort in sliderValue.OrderBy(sorted => sorted))
            {
                //Debug.Log(sort);
                sortArray[count] = sort;
                count++;
            }

            median = (sortArray[24] + sortArray[25]) / 2;
            quarter = sortArray[12];
            thirdQuarter = sortArray[37];

            Simulate();

            foreach (float sort2 in sliderValue.OrderBy(sorted => sorted))
            {
                //Debug.Log(sort);
                sortArray2[count2] = sort2;
                count2++;
            }

            median2 = (sortArray2[24] + sortArray2[25]) / 2;
            quarter2 = sortArray2[12];
            thirdQuarter2 = sortArray2[37];

            /// the values are in the follwing order: open high low close, start time , time durtaion
            // bottom point of box, top line end, bottom line end, top point of box, xPos 
            sideBySideBoxPlotChart.DataSource.AddCandleToCategory("Player 1", new CandleChartData.CandleValue(quarter, sortArray[49],
                sortArray[0], thirdQuarter, 5f, Random.value * 10f / 30f));

            sideBySideBoxPlotChart.DataSource.AddCandleToCategory("Player 2", new CandleChartData.CandleValue(quarter2, sortArray2[49],
                sortArray2[0], thirdQuarter2, 8f, Random.value * 10f / 30f));

            sideBySideBoxPlotChart.DataSource.EndBatch();
        }
    }
    

    public void barVertFullscreen()
    {
        if (verticalBarPlottGraph.activeSelf)
        {
            if (fullscreen)
            {
                barVertCanvas.offsetMin = new Vector2(50, 70); //left, bottom
                barVertCanvas.offsetMax = new Vector2(-50, -50); //-right, -top

                // canvas = GetComponent<RectTransform>(); //left, bottom
                // canvas.localScale = new Vector3(1, 1, 1);

                fullscreen = false;
            }
            else
            {
                barVertCanvas.offsetMin = new Vector2(100, 100);
                barVertCanvas.offsetMax = new Vector2(-100, -100);

                //canvas = GetComponent<RectTransform>(); //left, bottom
                //canvas.localScale = new Vector3(2, 2, 1);

                fullscreen = true;
            }
        }
    }

    public void barHorzFullscreen()
    {

        if (horizontalBarPlotGraph.activeSelf)
        {
            if (fullscreen)
            {
                barHorzCanvas.offsetMin = new Vector2(50, 50); //left, bottom
                barHorzCanvas.offsetMax = new Vector2(-50, -50); //-right, -top

                // canvas = GetComponent<RectTransform>(); //left, bottom
                // canvas.localScale = new Vector3(1, 1, 1);

                fullscreen = false;
            }
            else
            {
                barHorzCanvas.offsetMin = new Vector2(50, 140);
                barHorzCanvas.offsetMax = new Vector2(-50, -140);

                //canvas = GetComponent<RectTransform>(); //left, bottom
                //canvas.localScale = new Vector3(2, 2, 1);

                fullscreen = true;
            }
        }
    }

    public void pieChartFullscreen()
    {
        if (pieChartGraph.activeSelf)
        {
            if (fullscreen)
            {
                pieChartCanvas.transform.localScale = new Vector2(0.5f, 0.5f);
                fullscreen = false;
            }
            else
            {
                pieChartCanvas.transform.localScale = new Vector2(1f, 1f);
                fullscreen = true;
            }
        }
    }

    public void setGraphSize()
    {
        if (timeSeriesGraph.activeSelf)
        {
            if (fullscreen)
            {
                timeSeriesCanvas.offsetMin = new Vector2(50, 70); //left, bottom
                timeSeriesCanvas.offsetMax = new Vector2(-50, -50); //-right, -top
                fullscreen = false;
            }
            else
            {
                timeSeriesCanvas.offsetMin = new Vector2(100, 100);
                timeSeriesCanvas.offsetMax = new Vector2(-50, 50);
                fullscreen = true;
            }
        }
    }

    public void scrollBarMethod(int pageNumb)
    {
        if (pageNumb == 3)
        {

            if (pg3Scroll.value <= 1f && pg3Scroll.value >= 0.85f)
            {
                turnGraphOn("vBarPlot");
                if (animateVBar)
                {
                    BarAnimation vBar = verticalBarPlottGraph.GetComponentInChildren<BarAnimation>();
                    vBar.Animate();

                    animateVBar = false;
                    animateHBar = true;
                }
            }
            else if (pg3Scroll.value <= 0.66f && pg3Scroll.value >= 0.33f)
            {
                turnGraphOn("hBarPlot");
                if (animateHBar)
                {
                    BarAnimation hBar = horizontalBarPlotGraph.GetComponentInChildren<BarAnimation>();
                    hBar.Animate();

                    animateHBar = false;
                    animateVBar = true;
                }
            }
            else if(pg3Scroll.value <= 0.33f && pg3Scroll.value >= 0f)
            {
                turnGraphOn("sBarPlot");

                BarAnimation sBar = horizontalBarPlotGraph.GetComponentInChildren<BarAnimation>();
                sBar.Animate();
            }

            //Debug.Log(pg3Scroll.value);
        }
        else if (pageNumb == 4)
        {
            if (pg4Scroll.value <= 1f && pg4Scroll.value >= 0.85f)
            {
                turnGraphOn("histogram");
            }
            else if (pg4Scroll.value <= 0.85f && pg4Scroll.value >= 0.66f)
            {
                turnGraphOn("pieChart");
                //pieChartSimulate();
            }
            else if (pg4Scroll.value <= 0.66f && pg4Scroll.value >= 0.45f)
            {
                turnGraphOn("timeseries");
                //timeseriesSimulate();
            }
            else if (pg4Scroll.value <= 0.45f && pg4Scroll.value >= 0f)
            {
                turnGraphOn("scatter");
                //scatterPlotSimulate();
            }
            //Debug.Log(pg3Scroll.value);
        }
        else if (pageNumb == 5)
        {
            if (pg5Scroll.value <= 1f && pg5Scroll.value >= .5f)
            {
                //Debug.Log("Upper half");
                turnGraphOn("boxPlot");
            }
            else if (pg5Scroll.value <= 0.5f && pg5Scroll.value >= 0f)
            {
                //Debug.Log("Lower half");
                turnGraphOn("boxPlotHorz");
            }
            else
            {
                turnGraphOn("sideBySideBoxPlot");
            }
            //Debug.Log(pg3Scroll.value);
        }


        //if (3 == 3)
        //{
        //    Debug.Log(scrollbar.value);

        //    if (scrollbar.value == scrollbar.size / 2)
        //    {
        //        Debug.Log("HALFWAY!");
        //    }
        //}

    }
}
