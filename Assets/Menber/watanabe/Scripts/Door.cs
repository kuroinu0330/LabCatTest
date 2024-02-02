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

    // 追記 2/1 鳥海
    // 画面遷移時にフェードがかかるように
    public void Fade()
    {
        FadePanel.SetActive(true);
    }
}
