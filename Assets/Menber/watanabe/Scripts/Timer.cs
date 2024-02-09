using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;

    private bool stopTimer;
    [SerializeField]
    public bool startTimer = false;
    private void Start()
    {
        startTimer = true;
        if (startTimer == true)
        {
            stopTimer = false;
            timerSlider.maxValue = gameTime;
            timerSlider.value = gameTime;
        }
    }
    private void Update()
    {
        if (startTimer == true)
        {
            float time = gameTime - Time.time;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            if (time <= 0)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerSlider.value = time;
            }
        }

    }
}
