using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucnberScript : MonoBehaviour
{
    Animator cu_anim;

    void Start()
    {
        cu_anim = GetComponent<Animator>();

    }

    void Update()
    {
        cu_anim.SetBool("CucunberOn", true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
