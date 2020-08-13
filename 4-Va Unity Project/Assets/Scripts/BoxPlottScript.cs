using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class BoxPlottScript : MonoBehaviour
{
    //public GraphChart chart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointClick(GraphChart.GraphEventArgs args)
    {
        Debug.Log("The Value you've clicked is: " + args.Value.x + ", " + args.Value.y);
    }
}
