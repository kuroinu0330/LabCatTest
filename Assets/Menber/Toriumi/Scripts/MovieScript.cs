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

    // もし、途中で動画終わらせたかったらエスケープキーでスキップ

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        SceneManager.LoadScene("TutorialScene");
    //    }
    //}

    // videoが終わったらされる処理
    public void loopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("TutorialScene");
    }


}
