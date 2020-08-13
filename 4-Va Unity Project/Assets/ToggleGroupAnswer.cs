using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroupAnswer : MonoBehaviour
{

    public string answer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetAnswer(string currentAnswer)
    {
        answer = currentAnswer;
        //Debug.Log(answer);
    }
}
