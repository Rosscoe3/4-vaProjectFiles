using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToTop : MonoBehaviour
{
    //public GameObject scrollBar;
    // Start is called before the first frame update
    public void GoTop(GameObject scrollBar)
    {
        scrollBar.GetComponent<Scrollbar>().value = 1f;
    }
}
