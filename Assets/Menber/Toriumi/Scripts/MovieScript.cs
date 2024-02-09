using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MovieScript : MonoBehaviour
{
    [SerializeField]
    VideoPlayer video;
    
    void Start()
    {
        video.loopPointReached += loopPointReached;
    }

    // video‚ªI‚í‚Á‚½‚ç‚³‚ê‚éˆ—
    public void loopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("TitleSnTs");
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("TitleSnTs");
    }


}
