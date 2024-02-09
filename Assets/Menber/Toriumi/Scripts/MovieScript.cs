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

    // �����A�r���œ���I��点����������G�X�P�[�v�L�[�ŃX�L�b�v

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        SceneManager.LoadScene("TutorialScene");
    //    }
    //}

    // video���I������炳��鏈��
    public void loopPointReached(VideoPlayer vp)
    {
        SceneManager.LoadScene("TutorialScene");
    }


}
