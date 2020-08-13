using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Sends data to a google sheet

public class SendToGoogle : MonoBehaviour
{
    public GameObject testObject, popupPanel;

    public GameObject[] pages;

    static public string userName, hashString;
    public string chapterNumber;
    public float firstPageTime, secondPageTime, thirdPageTime, fourthPageTime, fifthPageTime, testTime;
    int numOfPages, testScore, simulationsRun;
    bool pgTimer, pg1Counted, pg2Counted = false;

    [SerializeField]
    //private readonly string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSchmYn3eRhFghjuvhNjnaWq2E1yJy52xp9Fnwo70r9HsZZdaw/formResponse";
    private readonly string BASE_URL = "https://docs.google.com/forms/u/5/d/e/1FAIpQLSedIkWpqxBSoMIYw3SAmOCYoJDhPWR6IV0KbH6pRsvFnD7bgw/formResponse";

    IEnumerator Post(string fullScreen)
    {
        int fullPageTime = (int)firstPageTime + (int)secondPageTime + (int)thirdPageTime + (int)fourthPageTime + (int)fifthPageTime;

        WWWForm form = new WWWForm();

        firstPageTime = (int)firstPageTime;
        secondPageTime = (int)secondPageTime;
        thirdPageTime = (int)thirdPageTime;
        fourthPageTime = (int)fourthPageTime;
        testTime = (int)testTime;

        form.AddField("entry.221353792", chapterNumber.ToString());
        form.AddField("entry.1742010422", firstPageTime.ToString() + " sec");
        form.AddField("entry.1182080020", secondPageTime.ToString() + " sec");
        form.AddField("entry.1355057801", thirdPageTime.ToString() + " sec");
        form.AddField("entry.601222025", fourthPageTime.ToString() + " sec");
        form.AddField("entry.826061747", fifthPageTime.ToString() + " sec");

   

        form.AddField("entry.493378778", fullPageTime.ToString() + " sec");
        form.AddField("entry.874469107", simulationsRun.ToString());
        form.AddField("entry.681231172", testTime.ToString() + " sec");
        form.AddField("entry.603472750", PopupPanel.clickedNumb);

        if (chapterNumber == "1")
        {
            form.AddField("entry.734400205", testScore + "/9");
        }
        else if (chapterNumber == "2")
        {
            form.AddField("entry.734400205", testScore + "/10");
        }

        form.AddField("entry.1760445013", hashString);

        Debug.Log(hashString);

        //using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form))
        //{
        //    yield return www.SendWebRequest();
        //    if (www.isNetworkError || www.isHttpError)
        //    {
        //        Debug.Log(www.error);
        //    }
        //    else
        //    {
        //        Debug.Log("Form upload complete!");
        //    }
        //}


        byte[] rawData = form.data;
#pragma warning disable CS0618//Type or member is obsolete
        WWW WWW = new WWW(BASE_URL, rawData);
#pragma warning disable CS0618//Type or member is obsolete
        yield return WWW;
        
    }

    void Update()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].activeSelf == true)
            {
                if (i == 0)
                {
                    firstPageTime = firstPageTime + Time.deltaTime;
                }
                else if (i == 1)
                {
                    secondPageTime = secondPageTime + Time.deltaTime;
                }
                else if (i == 2)
                {
                    thirdPageTime = thirdPageTime + Time.deltaTime;
                }
                else if (i == 3)
                {
                    fourthPageTime = fourthPageTime + Time.deltaTime;
                }
                else if (i == 4)
                {
                    fifthPageTime = fifthPageTime + Time.deltaTime;
                }
            }
        }

        //if (pages[0].activeSelf == true)
        //{
        //    firstPageTime = firstPageTime + Time.deltaTime;
        //}
        //if (pages[1].activeSelf == true)
        //{
        //    secondPageTime = secondPageTime + Time.deltaTime;
        //}
        //if (pages[2].activeSelf == true)
        //{
        //    thirdPageTime = thirdPageTime + Time.deltaTime;
        //}
        //if (pages[3].activeSelf == true)
        //{
        //    fourthPageTime = fourthPageTime + Time.deltaTime;
        //}

        //if (pages[4] != null)
        //{
        //    if (pages[4].activeSelf == true)
        //    {
        //        fifthPageTime = fifthPageTime + Time.deltaTime;
        //    }
        //}

        if (testObject.activeSelf == true)
        {
            testTime = testTime + Time.deltaTime;
        }

        //Debug.Log("1st page time: " + firstPageTime);
        //Debug.Log("2nd page time: " + secondPageTime);
        //Debug.Log("3rd page time: " + thirdPageTime);
        //Debug.Log("4th page time: " + fourthPageTime);
        //Debug.Log("5th page time: " + fifthPageTime);
        //Debug.Log("Quiz Time: " + testTime);
        //Debug.Log("Popup panels clicked: " + PopupPanel.clickedNumb);
    }

    public void Send()
    {
        Debug.Log("Sent!");

        if (chapterNumber == "1")
        {
            testScore = testObject.GetComponent<TestScript>().rightAnswers;
        }
        else if (chapterNumber == "2")
        {
            testScore = testObject.GetComponent<TestTwoScript>().rightAnswersNumb;
        }

        StartCoroutine(Post("yes"));
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

    public void TestResults(int rightAnswers)
    {
        testScore = rightAnswers;
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

    public void runSim()
    {
        simulationsRun++;
    }

    public void saveName(string name, string hash)
    {
        userName = name;
        hashString = hash;
        Debug.Log("Your username is: " + userName + ", And your hash is: " + hash);
    }
}
