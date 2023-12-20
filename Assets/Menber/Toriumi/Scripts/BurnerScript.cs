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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
