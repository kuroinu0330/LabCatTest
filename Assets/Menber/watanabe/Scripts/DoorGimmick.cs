using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ButtonController;
using static Timer;
public class DoorGimmick : MonoBehaviour
{
    //�؂�ւ���image
    [SerializeField]
    public Sprite newSprite;
    //���ݓ���Ă���image
    [SerializeField]
    public Sprite nowSprite;
    private Image image;
    private Animator anim;
    [SerializeField]
    public Door door;
    private void Start()
    {
        //�A�j���^�[�̃R���|�[�l���g
        anim = gameObject.GetComponent<Animator>();
        //�C���[�W�R���|�[�l���g
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ButtonController.instance.isCooldown == true)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                image.sprite = newSprite;
                //anim.SetBool("DoorBool", true);
                door.DoorMove();

                // �ύX 2/1 ���C
                // �b�� 3f -> 4f �ύX
                Invoke("SceneChange", 4.0f);
              
            }
            else
            {
                image.sprite = nowSprite;
            }
        }

    }
    private void SceneChange()
    {
        SceneManager.LoadScene("MainScene");
    }
}
