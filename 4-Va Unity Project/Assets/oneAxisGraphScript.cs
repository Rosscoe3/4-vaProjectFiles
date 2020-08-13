using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChartAndGraph;

public class oneAxisGraphScript : MonoBehaviour
{
    public Slider heightSlider;
    public Image point;

    float bValue, normal, localXPos, xPos;

    public float minHeight, maxHeight;
    bool isSliding = false;
    bool fullscreen;
    

    // Start is called before the first frame update
    void Start()
    {
        normal = Mathf.InverseLerp(heightSlider.minValue, heightSlider.maxValue, heightSlider.value);
        bValue = Mathf.Lerp(minHeight, maxHeight + normal * 3, normal);
        //xPos = -17f;
        point.rectTransform.localPosition = new Vector2(-17f, bValue);
    }

    // Update is called once per frame
    void Update()
    {
        normal = Mathf.InverseLerp(heightSlider.minValue, heightSlider.maxValue, heightSlider.value);
        bValue = Mathf.Lerp(minHeight, maxHeight + normal * 3, normal);

        if (fullscreen)
        {
            xPos = -36f;
        }
        else
        {
            xPos = -17f;
        }

        if (isSliding)
        {
            point.rectTransform.localPosition = new Vector2(xPos, bValue);
        }
        else
        {
            point.rectTransform.localPosition = new Vector2(xPos, bValue);
        }
    }

    public void moveSlider()
    {
        isSliding = true;
        //Debug.Log("Moving");
    }

    public void stopSlider()
    {
        isSliding = false;
        //Debug.Log("Stopped");
    }

    public void fullScreen()
    {
        if (fullscreen)
        {
            fullscreen = false;
        }
        else
        {
            fullscreen = true;
        }
    }
}
