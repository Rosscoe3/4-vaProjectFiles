using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class textCollisionColor : MonoBehaviour
{

    public Color textColor;
    public Color startColor;

    TextMeshProUGUI yearText;
    TextMeshProUGUI heightText;
    TextMeshProUGUI floodingDamageText;
    TextMeshProUGUI averageAnnualHighTemperatureText;


    // Start is called before the first frame update
    void Start()
    {
        yearText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        heightText = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        floodingDamageText = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        averageAnnualHighTemperatureText = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();

        yearText.color = startColor;
        heightText.color = startColor;
        floodingDamageText.color = startColor;
        averageAnnualHighTemperatureText.color = startColor;
    }

    public void OnMouseEnter()
    {
        //Debug.Log("TOUCHED");
        //Destroy(gameObject);
        yearText.color = textColor;
        heightText.color = textColor;
        floodingDamageText.color = textColor;
        averageAnnualHighTemperatureText.color = textColor;
    }

    public void OnMouseExit()
    {
        yearText.color = startColor;
        heightText.color = startColor;
        floodingDamageText.color = startColor;
        averageAnnualHighTemperatureText.color = startColor;
    }
}
