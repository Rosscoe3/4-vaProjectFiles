using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveMeanScript : MonoBehaviour
{
    public Image mean, median, legend;
    //public GameObject legend;

    bool fullscreen;

    public Vector3 meanPos, meanFullPos, medianPos, medianFullPos, legendPos, legendFullPos;
    public Vector2 meanSize, meanFullSize, medianSize, medianFullSize, legendSize, legendFullSize;

    public bool hasMedian;
    // Start is called before the first frame update
    void Start()
    {
        
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
