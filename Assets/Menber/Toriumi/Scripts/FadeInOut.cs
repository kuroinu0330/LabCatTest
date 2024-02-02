using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    // 好きに速度を変更してください。
    // この速度が体感最大位
    [SerializeField]
    float Speed = 0.01f;

    float alfa;

    public bool In = false;
    public bool Out = false;

    Image fadeImage;


    void Start()
    {
        fadeImage = GetComponent<Image>();
        alfa = fadeImage.color.a;
    }

    // test
    void Update()
    {
        if (In)
        {
            FadeIn();
        }

        if (Out)
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        alfa -= Speed;
        Alpha();

        if(alfa <= 0)
        {
            In = false;
            this.gameObject.SetActive(false);
        }
    }

    public void FadeOut()
    {
        alfa += Speed;
        Alpha();

        if (alfa >= 1)
        {
            Out = false;
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(0, 0, 0, alfa);
    }
}
