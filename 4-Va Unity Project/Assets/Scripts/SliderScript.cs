using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public GameObject water;
    public GameObject coverWater;
    public GameObject slider, run;
    public GameObject info;
    public GameObject pageManager;
    public GameObject yearTextObject, yearTextObject1;
    public GameObject sun;
    public GameObject heightSlider;
    public ParticleSystem rainParticles;
    public bool waterAlpha;

    public TextMeshProUGUI yearText, yearText1, sliderHandleText;
    public Button runSimButton;
    public int waterStartZ = 150;
    bool fullscreen = false;
    bool runBool = false;
    bool isIncreasing = true;
    bool showGraph;

    public float duration, startYear; 
    public float maxHeight = 0;
    public float minHeight = -5;
    float sliderValue, sliderValueLow, sliderValueHigh;
    float startTime, lastValue;
    int initialValue = 0;
    int temp;
    float coverWaterAlpha; 

    void Start()
    {
        lastValue = (int)slider.gameObject.GetComponent<Slider>().value;
        runSimButton.GetComponent<Button>().interactable = true;

        //rainParticles.Stop();
        coverWaterAlpha = 0.25f;

        sliderHandleText.text = "" + lastValue + "%";
        info.gameObject.SetActive(false);
        //coverWater.SetActive(false);
        yearText.text = "Year: " + startYear;
    }


    void Update()
    {
        sliderValue = slider.gameObject.GetComponent<Slider>().value;
        sliderValueLow = slider.gameObject.GetComponent<Slider>().minValue;
        sliderValueHigh = slider.gameObject.GetComponent<Slider>().maxValue;
        sliderHandleText.text = "" + Mathf.Round(sliderValue * 100f) + "%";

        //Debug.Log(coverWaterAlpha);

        yearText1.text = yearText.text;

        float normal = Mathf.InverseLerp(sliderValueLow, sliderValueHigh, sliderValue);

        float bValue = Mathf.Lerp(minHeight, maxHeight + normal * 3, normal);

        //coverWater.gameObject.transform.position = new Vector3(0, bValue, waterStartZ);
        water.gameObject.transform.position = new Vector3(0, bValue, waterStartZ);

        if (pageManager.GetComponent<PageManager>().pageIndex == 0)
        {
            slider.gameObject.SetActive(true);
            run.gameObject.SetActive(false);
            yearTextObject.gameObject.SetActive(false);
            yearTextObject1.gameObject.SetActive(false);
            //coverWater.SetActive(true);
            //LeanTween.value(coverWater, coverWaterAlpha, 0f, 1f, 1f);

            if (waterAlpha)
            {
                LeanTween.value(gameObject, 0f, 0.75f, 1.5f).setOnComplete(()=>{waterAlpha = false;}).setOnUpdate((float coverWaterAlpha) =>
                {;
                    coverWater.GetComponent<MeshRenderer>().material.SetFloat("Vector1_3CECC28A", coverWaterAlpha);
                    //Debug.Log("tweened value:" + coverWaterAlpha);
                });
            }


            if (!showGraph)
            {
                showGraph = true;
            }
        }

        else
        {
            //slider.gameObject.SetActive(false);
            run.gameObject.SetActive(true);
            yearTextObject.gameObject.SetActive(true);
            yearTextObject1.gameObject.SetActive(true);
            //coverWater.SetActive(false);

            //water.gameObject.transform.position = new Vector3(0, bValue, waterStartZ);

            //When the page is 
            if (waterAlpha)
            {
                LeanTween.value(gameObject, 0.75f, 0f, 1.5f).setOnComplete(()=>{waterAlpha = false;}).setOnUpdate((float coverWaterAlpha) =>
                {
                    ;
                    coverWater.GetComponent<MeshRenderer>().material.SetFloat("Vector1_3CECC28A", coverWaterAlpha);
                    //Debug.Log("tweened value:" + coverWaterAlpha);
                });
            }

            if (runBool)
            {
                //Moves through the years by adding them bezierly 
                float t = (Time.time - startTime) / duration;
                water.gameObject.transform.position = new Vector3(0, Mathf.SmoothStep(minHeight, maxHeight + normal * 3, t), waterStartZ);
                yearText.text = "Year: " + startYear;
                startYear = Mathf.SmoothStep(2000, 2051, t);
                startYear = (int)startYear;
                runSimButton.GetComponent<Button>().interactable = false;

                if (runSimButton.GetComponent<Button>().interactable == false)
                {
                    slider.GetComponent<Slider>().interactable = false;
                }


                //Rotates the sun around to simulate day and night
                float rotateXValue = Mathf.SmoothStep(0, 360 * 5, t);
                sun.transform.localEulerAngles = new Vector3(50 + rotateXValue, -240, 0);

                if (water.gameObject.transform.position == new Vector3(water.gameObject.transform.localPosition.x, maxHeight + normal * 3, water.gameObject.transform.localPosition.z))
                {
                    runBool = false;
                    runSimButton.GetComponent<Button>().interactable = true;
                    slider.GetComponent<Slider>().interactable = true;
                }
            }
        }

        if (fullscreen)
        {
            heightSlider.gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            heightSlider.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void RunSim()
    {
        startYear = 2000;
        runBool = true;
        startTime = Time.time;
    }

    public void changePage()
    {
        waterAlpha = true;
    }

    public void showInfo()
    {
        info.gameObject.SetActive(true);
    }

    public void fullScreen()
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
