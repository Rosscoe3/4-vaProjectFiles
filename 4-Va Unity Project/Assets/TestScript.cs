using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI questionA, questionB, questionC, questionD;
    public Image q1, q2, q3, q4;

    private string correctAnswer;
    public Toggle a, b, c, d;
    public Color selectedColor; 
    public TextMeshProUGUI buttonText, numberQuestionText, yourScore, percentage, wrongAnswerText, youMayWantToReviewText, moduleText;
    public Button myButton, finishButton;
    public GameObject test, testResults, testGameObject, sendToGoogle;

    private static TestScript instance;
    public bool testComplete, wrongAnswersComplete;
    int questionNumb;
    public int rightAnswers;

    public List<string> wrongAnswers = new List<string>();

    private void Awake()
    {
        test.SetActive(true);
        testGameObject.SetActive(true);
        testResults.SetActive(false);
        myButton.interactable = false;
        instance = this;
        var testData = FindObjectOfType<TestDataController>().Get(0);
        Show(testData);

        moduleText.text = "";

        a.isOn = false;
        b.isOn = false;
        c.isOn = false;
        d.isOn = false;

    }

    void Update()
    {
        if (questionNumb <= 7)
        {
            myButton.gameObject.SetActive(true);
            finishButton.gameObject.SetActive(false);
            numberQuestionText.text = questionNumb + 1 + "/9";
        }
        else if (questionNumb == 8)
        {
            //TURNS on the button to finish the test on the last question. 
            myButton.gameObject.SetActive(false);
            finishButton.gameObject.SetActive(true);
            numberQuestionText.text = questionNumb + 1 + "/9";
        }

        if (testComplete)
        {
            //When the test is done, show the right answers and the percentage
            yourScore.text = "you scored: " + rightAnswers + "/9";
            percentage.text = (float)rightAnswers / 9 * 100 + "%";

            if (wrongAnswers.Count > 0 && !wrongAnswersComplete)
            {
                //Cycles through the wrong answers, finds which module is associated with it, then displays which module to review
                for (int i = 0; i < wrongAnswers.Count; i++)
                {
                    if (i == 0)
                    {
                        wrongAnswerText.text = wrongAnswerText.text + " " + "#" + wrongAnswers[i];

                        if (wrongAnswers[i] == "1" || wrongAnswers[i] == "2")
                        {
                            moduleText.text = moduleText.text + "Module 1.1";
                        }
                        else if (wrongAnswers[i] == "3")
                        {
                            moduleText.text = moduleText.text + "Module 1.2";
                        }
                        else if (wrongAnswers[i] == "4")
                        {
                            moduleText.text = moduleText.text + "Module 1.3";
                        }
                        else if (wrongAnswers[i] == "5")
                        {
                            moduleText.text = moduleText.text + "Module 1.4";
                        }
                    }
                    else
                    {
                        wrongAnswerText.text = wrongAnswerText.text + ", " + "#" + wrongAnswers[i];

                        if (wrongAnswers[i] == "1" || wrongAnswers[i] == "2")
                        {
                            moduleText.text = moduleText.text + ", Module 1.1";
                        }
                        else if (wrongAnswers[i] == "3")
                        {
                            moduleText.text = moduleText.text + ", Module 1.2";
                        }
                        else if (wrongAnswers[i] == "4")
                        {
                            moduleText.text = moduleText.text + ", Module 1.3";
                        }
                        else if (wrongAnswers[i] == "5")
                        {
                            moduleText.text = moduleText.text + ", Module 1.4";
                        }
                    }
                }
                wrongAnswersComplete = true;
            }

            //If all answers where right
            if (wrongAnswers.Count == 0)
            {
                wrongAnswerText.gameObject.SetActive(false);
                youMayWantToReviewText.gameObject.SetActive(false);
                moduleText.gameObject.SetActive(false);
            }
        }

        if (a.isOn)
        {
            myButton.interactable = true;
            q1.color = selectedColor;
            q2.color = new Color(255, 255, 255);
            q3.color = new Color(255, 255, 255);
            q4.color = new Color(255, 255, 255);
        }
        else if (b.isOn)
        {
            myButton.interactable = true;
            q1.color = new Color(255, 255, 255);
            q2.color = selectedColor;
            q3.color = new Color(255, 255, 255);
            q4.color = new Color(255, 255, 255);
        }
        else if (c.isOn)
        {
            myButton.interactable = true;
            q1.color = new Color(255, 255, 255);
            q2.color = new Color(255, 255, 255);
            q3.color = selectedColor;
            q4.color = new Color(255, 255, 255);
        }
        else if (d.isOn)
        {
            myButton.interactable = true;
            q1.color = new Color(255, 255, 255);
            q2.color = new Color(255, 255, 255);
            q3.color = new Color(255, 255, 255);
            q4.color = selectedColor;
        }
        else
        {
            myButton.interactable = false;
            q1.color = new Color(255, 255, 255);
            q2.color = new Color(255, 255, 255);
            q3.color = new Color(255, 255, 255);
            q4.color = new Color(255, 255, 255);
        }
    }

    public void Show(TestData testData)
    {
        instance.title.text = testData.Question;
        instance.questionA.text = testData.a;
        instance.questionB.text = testData.b;
        instance.questionC.text = testData.c;
        instance.questionD.text = testData.d;
        instance.correctAnswer = testData.correctAnswer;

        //If there is no answer in test data then don't allow it to be touched. 
        if (instance.questionC.text == "")
        {
            Debug.Log("C is null!");
            c.enabled = false;
        }
        else
        {
            c.enabled = true;
        }
        if (instance.questionD.text == "")
        {
            Debug.Log("D is null!");
            d.enabled = false;
        }
        else
        {
            d.enabled = true;
        }
    }


    public void CheckAnswer()
    {
        Debug.Log(correctAnswer);

        if (a.isOn)
        {
            if (correctAnswer == "a")
            {
                rightAnswers++;
            }
            else
            {
                wrongAnswers.Add((questionNumb + 1).ToString());
            }
        }
        if (b.isOn)
        {
            if (correctAnswer == "b")
            {
                rightAnswers++;
            }
            else
            {
                wrongAnswers.Add((questionNumb + 1).ToString());
            }
        }
        if (c.isOn)
        {
            if (correctAnswer == "c")
            {
                rightAnswers++;
            }
            else
            {
                wrongAnswers.Add((questionNumb + 1).ToString());
            }
        }
        if (d.isOn)
        {
            if (correctAnswer == "d")
            {
                rightAnswers++;
            }
            else
            {
                wrongAnswers.Add((questionNumb + 1).ToString());
            }
        }

        if (questionNumb <= 7)
        {
            questionNumb++;
            var testData = FindObjectOfType<TestDataController>().Get(questionNumb);
            a.isOn = false;
            b.isOn = false;
            c.isOn = false;
            d.isOn = false;
            Show(testData);
        }
        else
        {
            testComplete = true;
            test.SetActive(false);
            testResults.SetActive(true);
            Debug.Log("you scored: " + rightAnswers + "/9");
            Debug.Log("wrong answers: " + rightAnswers + "/9");
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        testGameObject.SetActive(false);
    }
}
