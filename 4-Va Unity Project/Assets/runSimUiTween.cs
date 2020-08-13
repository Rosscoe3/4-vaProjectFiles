using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runSimUiTween : MonoBehaviour
{
    public float waitAmount = 30f;
    float time;
    bool isTweening;
    Vector3 scale;
    int counter = 1; 

    // Start is called before the first frame update
    void Start()
    {
        scale = gameObject.transform.localScale;
        //Expand();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(time);

        if (isTweening)
        {
            if (counter == 1)
            {
                Expand();
                counter = 0;
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time >= waitAmount)
            {
                isTweening = true;
                time = 0f;
            }
        }
    }

    public void Expand()
    {
        if (isTweening)
        {
            LeanTween.scale(gameObject, scale + new Vector3(0.25f, 0.25f, 0.25f), 0.5f).setOnComplete(Contract);
        }
    }

    public void Contract()
    {
        if (isTweening)
        {
            LeanTween.scale(gameObject, scale, 0.5f).setOnComplete(Expand);
        }
    }

    public void Click()
    {
        counter = 1; 
        time = 0f;
        waitAmount += 5f;
        isTweening = false;
        LeanTween.scale(gameObject, scale, 0.5f);
    }
}
