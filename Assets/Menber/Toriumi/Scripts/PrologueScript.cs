using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueScript : MonoBehaviour
{

    [SerializeField]
    GameObject movie;

    [SerializeField]
    float timeCount = 20f;
    [SerializeField]
    float time = 0f;

    bool playFlag;

    void Start()
    {
        movie.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MovieTime();
        MoviePlay();
        MovieStop();
    }

    public void MoviePlay()
    {
        if (playFlag == true)
        {
            movie.gameObject.SetActive(true);
        }
    }

    public void MovieStop()
    {
        if (movie.gameObject.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            playFlag = false;
            time = 0f;
            movie.gameObject.SetActive(false);
        }
    }

    public void MovieTime()
    {
        time += Time.deltaTime;

        if (time >= timeCount)
        {
            playFlag = true;
        }
    }


    public void MovieSceneChange()
    {
        SceneManager.LoadScene("MovieScene");
    }
}