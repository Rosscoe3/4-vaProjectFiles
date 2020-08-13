using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphScriptChapter3 : MonoBehaviour
{
    public GameObject meanBarplot, meanMedianBarplot; 

    // Start is called before the first frame update
    void Start()
    {
        meanBarplot.gameObject.SetActive(true);
        meanMedianBarplot.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void TurnOnGraph(string graphName)
    {
        if (graphName == "meanBarplot")
        {
            meanBarplot.gameObject.SetActive(true);
            meanMedianBarplot.gameObject.SetActive(false);
        }
        if (graphName == "meanMedianBarplot")
        {
            meanBarplot.gameObject.SetActive(false);
            meanMedianBarplot.gameObject.SetActive(true);
        }
    }
}
