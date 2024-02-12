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

    // video���I������炳��鏈��
    public void loopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("TitleSnTs");
    }

    public void SkipButton()
    {
        SceneManager.LoadScene("TitleSnTs");
    }


}
