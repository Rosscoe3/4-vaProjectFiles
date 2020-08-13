using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageButtonPositionScript : MonoBehaviour
{
    bool fullscreen;

    public Vector2 fullscreenPos;
    Vector2 initialPos;

    public GameObject pageManagerObj;

    PageManager pageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = GetComponent<RectTransform>().anchoredPosition;
        pageManagerScript = pageManagerObj.GetComponent<PageManager>();
    }

    void Update()
    {
        //Debug.Log(pageManagerScript.fullscreen);

        fullscreen = pageManagerScript.fullscreen;

        if (!fullscreen)
        {
            GetComponent<RectTransform>().anchoredPosition = initialPos;
        }
        else
        {
            GetComponent<RectTransform>().anchoredPosition = fullscreenPos;
        }
    }

    public void setFullScreen()
    {
        //if (fullscreen)
        //{
        //    //GetComponent<RectTransform>().anchoredPosition = new Vector2(142, 6);
        //    GetComponent<RectTransform>().anchoredPosition = initialPos;
        //    //GetComponent<RectTransform>().localPosition = initialPos;
        //    fullscreen = false;
        //}
        //else
        //{
        //    //GetComponent<RectTransform>().localPosition = fullscreenPos;
        //    //GetComponent<RectTransform>().anchoredPosition = new Vector2(142, 50);
        //    GetComponent<RectTransform>().anchoredPosition = fullscreenPos;
        //    fullscreen = true;
        //}
    }
}
