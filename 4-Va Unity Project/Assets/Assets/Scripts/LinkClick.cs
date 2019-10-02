using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkClick : MonoBehaviour
{
    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }
}
