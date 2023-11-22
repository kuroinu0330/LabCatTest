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
        // �o�[�i�[�A�j���[�V�������K�v�ȕ����ɉ��̃X�N���v�g�������Ă��������B

        if (Input.GetKeyDown(KeyCode.A))
        {
            // �o�[�i�[�A�j���[�V����ON
            anim.SetBool("BurnerOn", true);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            // �o�[�i�[�A�j���[�V����OFF
            anim.SetBool("BurnerOn", false);
        }

        // ���イ��̃A�j���[�V�������K�v�ȕ����ɉ��̃X�N���v�g�������Ă��������B

        if (Input.GetKeyDown(KeyCode.W))
        {
            // ���イ��A�j���[�V����ON
            anim.SetBool("CucunberOn", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // ���イ��A�j���[�V����OFF
            anim.SetBool("CucunberOn", false);
        }
    }

}
