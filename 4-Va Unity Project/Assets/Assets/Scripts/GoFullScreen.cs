using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFullScreen : MonoBehaviour
{
    int buttonCounter = 1;
    public GameObject cam2;
    public GameObject cam3;

    public bool graphing;
    public GameObject graphUI;

    public void FullScreenMode(GameObject camera)
    {
        Rect oldSize;
        if (camera.gameObject.CompareTag("eCam"))
        {
            oldSize = new Rect(0f, 0.5f, 0.5f, 0.5f);
        }
        else if (camera.gameObject.CompareTag("tCam"))
        {
            oldSize = new Rect(0f, 0f, 1f, 0.5f);
        }
        else
        {
            oldSize = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        }
        //Debug.Log("old:" + oldSize);


        if(buttonCounter % 2 == 0)
        {
            camera.gameObject.GetComponent<Camera>().rect = oldSize;
            //Debug.Log(buttonCounter);
            //Debug.Log(camera.gameObject.GetComponent<Camera>().rect);
            cam2.SetActive(true);
            cam3.SetActive(true);

            if (graphing)
            {
                graphUI.SetActive(true);
            }
        }
        else
        {
            Rect fullscreen = new Rect(0, 0, 1, 1);
            camera.gameObject.GetComponent<Camera>().rect = fullscreen;
            cam2.SetActive(false);
            cam3.SetActive(false);

            if (graphing)
            {
                graphUI.SetActive(false);
            }
        }
        buttonCounter++;
    }

    public void hideThisOne(GameObject camera2)
    {
        camera2.gameObject.SetActive(false);
        if (graphing)
        {
            graphUI.SetActive(true);
        }
    }
}
