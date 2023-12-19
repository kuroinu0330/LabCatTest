using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudAnimation : MonoBehaviour
{
    // 雲のスピード
    public float CloudSpeed = 0.5f;


    // 雲の
    Vector2 CloudStart;
    Vector2 CloudFinish;

    // 雲が動く範囲
    int c_Start = 18;
    int c_Finish = -18;

    RectTransform rect;
    private void Start()
    {
        CloudStart.x = c_Start;
        CloudFinish.x = c_Finish;
    }

    void Update()
    {
        if (transform.position.x <= CloudFinish.x)
        {
            transform.position = new Vector2(CloudStart.x, CloudStart.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, CloudFinish, CloudSpeed * Time.deltaTime);

    }
}
