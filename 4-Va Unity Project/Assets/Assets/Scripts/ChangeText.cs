using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public GameObject secondScreen;

    public GameObject scrollBar;

    public void LoadText(GameObject firstScreen)
    {
        Debug.Log("load dat text");

        firstScreen.gameObject.SetActive(false);
        secondScreen.gameObject.SetActive(true);

        scrollBar.GetComponent<Scrollbar>().value = 1f;
    }

}
