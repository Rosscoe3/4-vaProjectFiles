using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI description;
    //[SerializeField]
    //private Image image;

    private static PopupPanel instance;
    public static int clickedNumb;
    public GameObject panel;
    public GameObject background;

    Vector3 scale;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
        scale = panel.transform.localScale;
    }

    public static void Show(ItemData itemData)
    {

        instance.panel.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(instance.panel, instance.scale, 0.5f);
        LeanTween.alpha(instance.background.GetComponent<RectTransform>(), .6f, 0.5f);

        clickedNumb++;
        instance.title.text = itemData.Name;
        instance.description.text = itemData.Description;
        //instance.image.sprite = itemData.sprite;
        instance.gameObject.SetActive(true);
    }

    public void Close()
    {
        LeanTween.scale(panel, new Vector3(0, 0, 0), 0.5f).setOnComplete(Hide);
        LeanTween.alpha(background.GetComponent<RectTransform>(), 0f, 0.5f);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
