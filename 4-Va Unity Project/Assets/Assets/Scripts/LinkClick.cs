using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class LinkClick : MonoBehaviour
{
    public void OpenLink(string url)
    {
        //Application.OpenURL(url);

        #if !UNITY_EDITOR
            openWindow(url);
        #endif
    }
}
