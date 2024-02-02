using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    GameObject FadePanel;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DoorMove()
    {
        anim.SetBool("DoorBool",true);
    }

    // �ǋL 2/1 ���C
    // ��ʑJ�ڎ��Ƀt�F�[�h��������悤��
    public void Fade()
    {
        FadePanel.SetActive(true);
    }
}
