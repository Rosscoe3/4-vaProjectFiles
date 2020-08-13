using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestTwoScript : MonoBehaviour
{
    public GameObject testContent, finishTestContent; 
    public GameObject[] toggleGroups;

    public Scrollbar scroll;
    public Button finishButton;

    public TextMeshProUGUI yourScore, percentage, wrongAnswerText, youMayWantToReviewText, moduleText, notAnsweredText;

    public string[] rightAnswers;
    public string[] finalAnswers;
    bool[] wrongAnwers = new bool[10];

    bool allAnswered;

    public int rightAnswersNumb;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        testContent.SetActive(false);
        finishTestContent.SetActive(false);

        moduleText.text = "";
    }

    public void turnOnTest()
    {
        gameObject.SetActive(true);
        testContent.SetActive(true);
        finishTestContent.SetActive(false);

        scroll.value = 1f;

        notAnsweredText.gameObject.SetActive(false);

        for (int i = 0; i < toggleGroups.Length; i++)
        {
            toggleGroups[i].GetComponent<ToggleGroup>().SetAllTogglesOff();
        }
    }

    void Update()
    {
        for (int i = 0; i < toggleGroups.Length; i++)
        {
            if (toggleGroups[i].GetComponent<ToggleGroup>().AnyTogglesOn())
            {
                allAnswered = true;
            }
            else
            {
                allAnswered = false;
            }
        }

        //if (!allAnswered)
        //{
        //    notAnsweredText.gameObject.SetActive(true);
        //    finishButton.interactable = false;
        //}
        //else
        //{
        //    notAnsweredText.gameObject.SetActive(false);
        //    finishButton.interactable = true;
        //}
    }

    public void turnOffTest()
    {
        gameObject.SetActive(false);
        testContent.SetActive(false);
    }

    public void CheckAnswers()
    {
        testContent.SetActive(false);
        finishTestContent.SetActive(true);

        for (int i = 0; i < toggleGroups.Length; i++)
        {
            ToggleGroupAnswer tga = toggleGroups[i].GetComponent<ToggleGroupAnswer>();
            finalAnswers[i] = tga.answer;

            //If the answer is right
            if (finalAnswers[i] == rightAnswers[i])
            {
                rightAnswersNumb++;
                wrongAnwers[i] = false;
            }
            //If its wrong
            else
            {
                wrongAnwers[i] = true;
            }

            Debug.Log(finalAnswers[i]);
        }

        testContent.SetActive(false);
        finishTestContent.SetActive(true);

        //When the test is done, show the right answers and the percentage
        yourScore.text = "you scored: " + rightAnswersNumb + "/10";
        percentage.text = ((float)rightAnswersNumb / 10 * 100) + "%";

        if ((10 - rightAnswersNumb) == 0)
        {
            youMayWantToReviewText.gameObject.SetActive(false);
            moduleText.gameObject.SetActive(false);
        }
        else
        {
        }

        for (int x = 0; x < wrongAnwers.Length; x++)
        {
            if (wrongAnwers[x] == true)
            {
                if (x == 0)
                {
                    if (!moduleText.text.Contains("Module 2.1"))
                    {
                        moduleText.text = moduleText.text + " Module 2.1";
                    }
                }
                else if (x == 1 || x == 2 || x == 3 || x == 4)
                {
                    if (!moduleText.text.Contains("Module 2.2"))
                    {
                        moduleText.text = moduleText.text + " Module 2.2";
                    }
                }
                else if (x == 5 || x == 6 || x == 7 || x == 8 || x == 9)
                {
                    if (!moduleText.text.Contains("Module 2.4"))
                    {
                        moduleText.text = moduleText.text + " Module 2.4";
                    }
                }
            }

        }

        Debug.Log(allAnswered);

        Debug.Log("Right Answers: " + rightAnswersNumb + " Wrong Answers: " + (toggleGroups.Length - rightAnswersNumb));
    }
}
