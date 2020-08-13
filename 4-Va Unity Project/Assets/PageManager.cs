using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    public GameObject[] pages, tutorialPopups;
    public TextMeshProUGUI[] pageDescriptions;
    public float[] fullScreenFont;
    public Button[] toTestButton;
    public bool tutorialPopupsOn, fullscreen;

    bool testDone;
    public int pageIndex = 0;

    void Start()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (!(i == pageIndex))
            {
                pages[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (!(i == pageIndex))
            {
                pages[i].gameObject.SetActive(false);
            }
            else
            {
                pages[pageIndex].gameObject.SetActive(true);
            }
        }

        if (testDone)
        {
            toTestButton[0].interactable = false;
            toTestButton[1].interactable = false;

        }

        for (int i = 0; i < pageDescriptions.Length; i++)
        {
            if (fullscreen)
            {
                //if (i == 4)
                //{
                //    toTestButton.
                //}
                pageDescriptions[i].fontSize = fullScreenFont[i];
            }
            else
            {
                pageDescriptions[i].fontSize = 18;
            }
        }

        if (tutorialPopupsOn)
        {
            if (pageIndex == 0)
            {
                tutorialPopups[0].gameObject.SetActive(true);
                tutorialPopups[1].gameObject.SetActive(false);
                tutorialPopups[2].gameObject.SetActive(false);
            }
            else if (pageIndex == 1)
            {
                tutorialPopups[0].gameObject.SetActive(false);
                tutorialPopups[1].gameObject.SetActive(true);
                tutorialPopups[2].gameObject.SetActive(false);
            }
            else if (pageIndex == 2)
            {
                tutorialPopups[0].gameObject.SetActive(false);
                tutorialPopups[1].gameObject.SetActive(false);
                tutorialPopups[2].gameObject.SetActive(true);
            }
            else if (pageIndex == 3)
            {
                tutorialPopups[0].gameObject.SetActive(false);
                tutorialPopups[1].gameObject.SetActive(false);
                tutorialPopups[2].gameObject.SetActive(true);
            }
        }
    }

    public void turnTutorialPopupsOn()
    {
        tutorialPopupsOn = true;
    }

    public void PageForward()
    {
        pageIndex++;
    }

    public void PageBackward()
    {
        pageIndex--;
    }

    public void endTest()
    {
        pageIndex = 0;
        testDone = true;
    }

    public void goToPage(int pageNumb)
    {
        pageIndex = pageNumb;
    }

    public void Fullscreen()
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
