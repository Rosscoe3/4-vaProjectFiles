using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Sends data to a google sheet

public class SendToGoogle : MonoBehaviour
{
    public GameObject pg1, pg2;

    public float firstPageTime, secondPageTime;
    int numOfPages = 0;
    bool pgTimer, pg1Counted, pg2Counted = false;

    [SerializeField]
    private readonly string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSchmYn3eRhFghjuvhNjnaWq2E1yJy52xp9Fnwo70r9HsZZdaw/formResponse";

    IEnumerator Post(string fullScreen)
    {
        int fullPageTime = (int)firstPageTime + (int)secondPageTime;

        WWWForm form = new WWWForm();
        form.AddField("entry.2053915795", fullScreen);
        form.AddField("entry.30887264", firstPageTime.ToString());
        form.AddField("entry.530696884", secondPageTime.ToString());
        form.AddField("entry.923004832", fullPageTime.ToString());
        form.AddField("entry.2038010638", numOfPages.ToString());

        byte[] rawData = form.data;
#pragma warning disable CS0618//Type or member is obsolete
        WWW WWW = new WWW(BASE_URL, rawData);
#pragma warning disable CS0618//Type or member is obsolete
        yield return WWW;

        //using (UnityWebRequest WWW = UnityWebRequest.Post(BASE_URL, form))
        //{
        //    yield return WWW.SendWebRequest();
        //    if (WWW.isNetworkError || WWW.isHttpError)
        //    {
        //        Debug.Log(WWW.error);
        //    }
        //    else
        //    {
        //        Debug.Log("Form upload complete!");
        //    }
        //}
    }

    void Update()
    {
        if (pgTimer && pg1.activeSelf == true)
        {
            firstPageTime = firstPageTime + Time.deltaTime;
        }
        if (pgTimer && pg2.activeSelf == true)
        {
            secondPageTime = secondPageTime + Time.deltaTime;
        }

       Debug.Log("1st page time: " + firstPageTime);
       Debug.Log("2nd page time: " + secondPageTime);
        Debug.Log(numOfPages);
    }

    public void Send()
    {
        StartCoroutine(Post("yes"));
        Debug.Log("Sent!");
    }

    public void PageTimer()
    {
        if (pgTimer)
        {
            pgTimer = false;
        }
        else
        {
            pgTimer = true;
        }
    }

    public void TurnPage(string pageName)
    {
        if (pageName == "1" && !pg1Counted)
        {
            numOfPages++;
            pg1Counted = true;
        }
        if (pageName == "2" && !pg2Counted)
        {
            numOfPages++;
            pg2Counted = true;
        }
    }
}
