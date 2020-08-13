using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;

public class videoPlayer : MonoBehaviour
{
    private static string url;

    // Start is called before the first frame update
    void Awake()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "TutorialVid4-va_2.mp4");
        //videoPlayer.Play();
    }
}
