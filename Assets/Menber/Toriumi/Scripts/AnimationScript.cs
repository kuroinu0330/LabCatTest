using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationScript : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // バーナーアニメーションが必要な部分に下のスクリプトを書いてください。

        if (Input.GetKeyDown(KeyCode.A))
        {
            // バーナーアニメーションON
            anim.SetBool("BurnerOn", true);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            // バーナーアニメーションOFF
            anim.SetBool("BurnerOn", false);
        }

        // きゅうりのアニメーションが必要な部分に下のスクリプトを書いてください。

        if (Input.GetKeyDown(KeyCode.W))
        {
            // きゅうりアニメーションON
            anim.SetBool("CucunberOn", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // きゅうりアニメーションOFF
            anim.SetBool("CucunberOn", false);
        }
    }

}
