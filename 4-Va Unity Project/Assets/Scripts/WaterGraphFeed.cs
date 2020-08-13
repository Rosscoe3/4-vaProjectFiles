using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChartAndGraph;

public class WaterGraphFeed : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider heightSlider, noiseSlider;
    public float noiseValue;
    public RectTransform graphRect;
    public bool fullscreen;
    public float slope, yIntercept;
    public RandomFromDistribution.ConfidenceLevel_e conf_level = RandomFromDistribution.ConfidenceLevel_e._95;
    public float[] sliderValue, noise;

    void Start()
	{
        //HorizontalAxis horizontalAxis = GetComponent<HorizontalAxis>();
        //horizontalAxis.SubDivisions.TextPrefix = "10";

        //noiseValue = noiseSlider.maxValue/2;
        //Simulate();
    }

    public void Simulate()
    {
        slope = heightSlider.value;
        GraphChart graph = GetComponent<GraphChart>();
        HorizontalAxis horizontalAxis = GetComponent<HorizontalAxis>();

        //HorizontalAxis prefix = gameObject.GetComponent<HorizontalAxis>();
        //prefix.useGUILayout = true;
        //prefix.text
        //prefix.textPrefix = 0;

        if (graph != null)
        {
            graph.DataSource.StartBatch();  // start a new update batch
            graph.DataSource.ClearCategory("Player 1");  // clear the categories we have created in the inspector
            graph.DataSource.ClearCategory("Player 3");
            graph.DataSource.ClearAndMakeBezierCurve("Player 2");

            for (int i = 1970; i < 2021; i++)
            {
                noise[i-1970] = RandomFromDistribution.RandomRangeNormalDistribution(-noiseValue, noiseValue, conf_level);

                //slope is set with the slider value, changes how fast it increases. Do NOT cover up water in first year
                // add noise to every point, so they keep getting worse/better. noise + noise[i-1];
                //Run simulation 10 times in background after clicking, generate its possible points on that year. 

                sliderValue[i-1970] = (slope * (i-1970)) + yIntercept;

                //if (i < 10)
                //{
                //    horizontalAxis.MainDivisions.TextPrefix = "200";
                //}
                //else if (i > 10)
                //{
                //    horizontalAxis.MainDivisions.TextPrefix = "20";
                //}

                if (i == 1970)
                {
                    graph.DataSource.SetCurveInitialPoint("Player 2", 1970, sliderValue[i-1970] + noise[i-1970]); //+ heightSlider.value / 4
                }
                else if (i == 2020)
                {
                    graph.DataSource.AddLinearCurveToCategory("Player 2", new DoubleVector2(i, sliderValue[i-1970]));
                }
                if (i != 1970)
                {
                    sliderValue[i-1970] += noise[i - 1971] + noise[i-1970];
                }

                //add 50 random points , each with a category and an x,y value
                graph.DataSource.AddPointToCategory("Player 1", i, sliderValue[i-1970]);
                //graph.DataSource.AddLinearCurveToCategory("Player 2", new DoubleVector2(i, sliderValue));
            }
            graph.DataSource.MakeCurveCategorySmooth("Player 2");
            graph.DataSource.EndBatch(); // end the update batch . this call will render the graph
        }
    }

    public void setGraphSize()
    {
        if (fullscreen)
        {
            graphRect.offsetMin = new Vector2(50, 70); //left, bottom
            graphRect.offsetMax = new Vector2(-50, -50); //-right, -top
            fullscreen = false;
        }
        else
        {
            graphRect.offsetMin = new Vector2(100, 100);
            graphRect.offsetMax = new Vector2(-50, 50);
            fullscreen = true;
        }
    }

    //public void OnPointClick(GraphChart.GraphEventArgs args)
    //{
    //    Debug.Log("The Value you've clicked is: " + args.Value.x + ", " + args.Value.y);

    //    GraphChart graph = GetComponent<GraphChart>();
    //    if (graph != null)
    //    {
    //        //float addBoxPlott = 0.1f;

    //        if (!args.Category.Contains("Player 3"))
    //        {
    //            graph.DataSource.StartBatch();
    //            graph.DataSource.ClearCategory("Player 3");

    //            for (int x = 0; x < 10; x++)
    //            {
    //                for (int i = 0; i < 50; i++)
    //                {
    //                    noise[i] = RandomFromDistribution.RandomRangeNormalDistribution(-noiseValue, noiseValue, conf_level);
    //                    sliderValue[i] = (slope * i) + yIntercept;

    //                    if (i != 0)
    //                    {
    //                        sliderValue[i] += noise[i - 1] + noise[i];
    //                    }
    //                }
    //                graph.DataSource.AddPointToCategory("Player 3", args.Value.x, sliderValue[(int)args.Value.x]);
    //            }
    //            graph.DataSource.EndBatch();
    //        }

    //        else
    //        {
    //            graph.DataSource.StartBatch();  // start a new update batch
    //            graph.DataSource.ClearCategory("Player 4");  // clear the categories we have created in the inspector

    //            for (int i = 0; i < 50; i++)
    //            {
    //                float noise = RandomFromDistribution.RandomRangeNormalDistribution(-noiseValue, noiseValue, conf_level);
    //                float sliderValue;
    //                if (i == 0)
    //                {
    //                    sliderValue = (float)args.Value.y;
    //                    graph.DataSource.AddPointToCategory("Player 4", args.Value.x + i, args.Value.y);
    //                }
    //                else
    //                {
    //                    sliderValue = (slope * i) + (float)args.Value.y;
    //                    graph.DataSource.AddPointToCategory("Player 4", args.Value.x + i, args.Value.y + sliderValue + noise + heightSlider.value / 4);
    //                }

    //            }
    //            graph.DataSource.EndBatch(); // end the update batch . this call will render the graph
    //        }
    //    }
    //}
}
