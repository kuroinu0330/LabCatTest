using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFlag : MonoBehaviour
{
    public bool isActive = false;

    public void ActiveTrue()
    {
        //anim.SetBool("AcBool", true);
        //�A�j���[�V�������I�������isActive��True�ɂ���B
        isActive = true;
        //Destroy(GetComponent<Animator>());
    }
}
