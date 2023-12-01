using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerScript : MonoBehaviour
{
    Animator bu_anim;

    void Start()
    {
        bu_anim = GetComponent<Animator>();

    }

    void Update()
    {
        bu_anim.SetBool("BurnerOn", true);
    }
}
