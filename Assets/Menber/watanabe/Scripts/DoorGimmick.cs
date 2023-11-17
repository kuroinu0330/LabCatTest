using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorGimmick : MonoBehaviour
{
    [SerializeField]
    public Sprite newSprite;
    [SerializeField]
    public Sprite nowSprite;
    private Image image;
    private Animator anim;
    [SerializeField]
    public Door door;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("—Ìˆæ“WŠJ");
            image.sprite = newSprite;
            //anim.SetBool("DoorBool", true);
            door.DoorMove();
        }
        else
        {
            image.sprite = nowSprite;
        }
    }
}
