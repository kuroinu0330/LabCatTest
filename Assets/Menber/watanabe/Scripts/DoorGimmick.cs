using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ButtonController;
using static Timer;
public class DoorGimmick : MonoBehaviour
{
    //切り替えるimage
    [SerializeField]
    public Sprite newSprite;
    //現在入れているimage
    [SerializeField]
    public Sprite nowSprite;
    private Image image;
    private Animator anim;
    [SerializeField]
    public Door door;
    private void Start()
    {
        //アニメターのコンポーネント
        anim = gameObject.GetComponent<Animator>();
        //イメージコンポーネント
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

                // 変更 2/1 鳥海
                // 秒数 3f -> 4f 変更
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
