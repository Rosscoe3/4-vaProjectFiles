using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject background;
    public bool fadeOnAwake = false;
    public float transparencyTo = 0.6f;

    Vector3 scale;

    private void Start()
    {
        gameObject.SetActive(false);
        scale = panel.transform.localScale;

        if (fadeOnAwake)
        {
            Show();
        }
    }

    private void Awake()
    {
    }

    public void Show()
    {
        gameObject.SetActive(true);
        panel.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(panel, scale, 0.5f);
        LeanTween.alpha(background.GetComponent<RectTransform>(), transparencyTo, 0.5f);
    }

    public void Close()
    {
        LeanTween.scale(panel, new Vector3(0, 0, 0), 0.5f).setOnComplete(Hide);
        LeanTween.alpha(background.GetComponent<RectTransform>(), 0f, 0.5f);
    }

    void Hide()
    {
        gameObject.SetActive(false);

        if (fadeOnAwake)
        {
            panel.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
        }
    }
}
