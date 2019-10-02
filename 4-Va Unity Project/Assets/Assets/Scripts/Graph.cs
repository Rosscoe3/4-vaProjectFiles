using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//a class that creates a plot-point graph of the data viz
public class Graph : MonoBehaviour
{
    //series of graph dots
    [SerializeField] private Sprite circleSprite;
    //the transform of the graph's container
    private RectTransform graphContainer;
    //can now set the data values in the editor
    public List<int> values;

    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;

    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;


    //upon play
    private void Awake()
    {
        //find the rect transform of the graph's container
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();

        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

        //list of values to be plotted
        List<int> valueList = values;//new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 25, 37, 40, 36, 33 };
        ShowGraph(valueList);
    }


    //creates the plot points
    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        //instantiate the plot points and then apply them to the graph's container
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;

        //create the rect transform for the plot points
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        //set the plot points' size and anchors
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        //returns the plot point
        return gameObject;
    }


    //form the actual graph
    private void ShowGraph(List<int> valueList)
    {
        //set the graph size
        float graphHeight = 200;//graphContainer.sizeDelta.y;
        float yMax = 100f;
        float xSize = 50f;

        //set the defualt value of the next point to null
        GameObject lastCirlceGameObject = null;

        //go through the data and plot the points
        for (int i = 0; i < valueList.Count; i++)
        {
            //set the point positions and then instantiate them
            float xPosition = i * xSize;
            float yPosition = (valueList[i] / yMax) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));

            //check if it is the last point in the graph
            if(lastCirlceGameObject != null)
            {
                CreateDotConnection(lastCirlceGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }

            //go through the data to the next point
            lastCirlceGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -20);
            labelX.GetComponent<Text>().text = i.ToString();

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, -4f);
        }

        int seperatorCount = 10;
        for (int i = 0; i <= seperatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / seperatorCount;
            labelY.anchoredPosition = new Vector2(-20f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMax).ToString();

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
        }
    }


    //draw lines to connect the dots
    private void CreateDotConnection(Vector2 dotPosA, Vector2 dotPosB)
    {
        //instantiate the lines, specifiying color and opacity, and set them to the graph's container
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);

        //calculate the distance between the points
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPosB - dotPosA).normalized;
        float distance = Vector2.Distance(dotPosA, dotPosB);

        //set the rotation and size of the lines to appropriately connect the dots
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 5f);
        rectTransform.anchoredPosition = dotPosA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
    }


    //the math calculations of the lines' rotations and directions
    public static float GetAngleFromVectorFloat(Vector2 dir) 
    {
        //math
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //make sure it stays within the correct bounds
        if (n < 0)
            n += 360;

        //returns the correct rotation
        return n;
     }﻿
}
