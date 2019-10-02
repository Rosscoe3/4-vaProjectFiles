using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Sends data to a google sheet

public class SendToGoogle : MonoBehaviour
{
    public float firstPageTime;
    string firstPageTimeString;
    bool pg1Timer = false;

    [SerializeField]
    private readonly string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSchmYn3eRhFghjuvhNjnaWq2E1yJy52xp9Fnwo70r9HsZZdaw/formResponse";

    IEnumerator Post(string fullScreen)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2053915795", fullScreen);
        form.AddField("entry.30887264", firstPageTime.ToString());

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
        if (pg1Timer)
        {
            firstPageTime = +Time.time;
        }
        //Debug.Log(firstPageTime);
    }

    public void Send()
    {
        StartCoroutine(Post("yes"));
        Debug.Log("Clicked");
    }

    public void PageOne()
    {
        if (pg1Timer)
        {
            pg1Timer = false;
        }
        else
        {
            pg1Timer = true;
        }
    }
}
