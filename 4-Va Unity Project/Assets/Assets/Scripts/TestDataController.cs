using System;
using System.Linq;
using UnityEngine;

public class TestDataController : MonoBehaviour
{
    [SerializeField]
    public TestData[] testQuestions;

    //public GameObject[] decklist;
    private TestData tempGO;

    void Start()
    {
        //for (int i = 0; i < testQuestions.Length; i++)
        //{
        //    Debug.Log(i + " " + "Unshuffled: " + testQuestions[i].Question);
        //}
        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = 0; i < testQuestions.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, testQuestions.Length);
            tempGO = testQuestions[rnd];
            testQuestions[rnd] = testQuestions[i];
            testQuestions[i] = tempGO;
        }
        //for (int i = 0; i < testQuestions.Length; i++)
        //{
        //    Debug.Log(i + " " + "Shuffled: " + testQuestions[i].Question);
        //}
    }

    public TestData Get(int index)
    {
        //int rnd;
        //rnd = UnityEngine.Random.Range(0, testQuestions.Length);

        return testQuestions[index];
    }
}

[Serializable]
public struct TestData
{
    public string Question;
    public string a;
    public string b;
    public string c;
    public string d;
    public string correctAnswer;
}
