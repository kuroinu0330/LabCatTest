using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFlag : MonoBehaviour
{
    public bool isActive = false;

    public void ActiveTrue()
    {
        //anim.SetBool("AcBool", true);
        //アニメーションが終わったらisActiveをTrueにする。
        isActive = true;
        //Destroy(GetComponent<Animator>());
    }
}
