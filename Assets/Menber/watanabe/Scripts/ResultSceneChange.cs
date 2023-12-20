using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneChange : MonoBehaviour
{
    // �S�̓I�ɕύX 12/20 ���C

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
                // �X�����ύX�Ȃ�
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
