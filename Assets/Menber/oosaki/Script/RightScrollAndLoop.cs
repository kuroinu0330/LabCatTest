using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScrollAndLoop : MonoBehaviour
{
    public RectTransform scrollPanel;
    public float scrollSpeed = 50f;
    public float loopPosition = 1000f; // ループ位置
    public float loopTime = 10f; // ループする時間

    private float loopTimer = 0f;
    private bool isLooping = false;

    void Update()
    {
        Vector2 newPos = scrollPanel.anchoredPosition;
        newPos.x += scrollSpeed * Time.deltaTime;

        if (!isLooping && newPos.x > loopPosition)
        {
            isLooping = true;
            newPos.x = 0f; // ループの最初の位置に戻す
        }

        if (isLooping)
        {
            loopTimer += Time.deltaTime;

            if (loopTimer >= loopTime)
            {
                loopTimer = 0f;
                isLooping = false;
            }
            else if (newPos.x > loopPosition)
            {
                newPos.x = 0f; // ループの最初の位置に戻す
            }
        }

        scrollPanel.anchoredPosition = newPos;
    }
}