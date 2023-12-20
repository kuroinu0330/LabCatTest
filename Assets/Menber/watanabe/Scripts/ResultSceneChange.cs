using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneChange : MonoBehaviour
{
    // 全体的に変更 12/20 鳥海

    [SerializeField]
    GameObject FadePanel;

    BossCatScript bossCat;

    float alpha = 1f;

    private void Start()
    {
        bossCat = GetComponent<BossCatScript>();
    }

    private void Update()
    {
        ResultScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FadePanel.SetActive(true);
        }
    }

    public void ResultScene()
    {
        if(bossCat.BossCatHP > 0)
        {
            if (FadePanel.GetComponent<Image>().color.a >= alpha)

            {
                // 個々だけ変更なし
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
