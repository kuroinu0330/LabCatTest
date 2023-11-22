using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatCounter : MonoBehaviour
{
    public GameObject targetObject; // �C���X�y�N�^�[��ŃI�u�W�F�N�g���w��
    public Text countText;

    void Update()
    {
        if (targetObject != null)
        {
            // �^�[�Q�b�g�ƂȂ�I�u�W�F�N�g�������A���𐔂���
            int objectCount = GameObject.FindGameObjectsWithTag(targetObject.tag).Length;

            // �e�L�X�g�ɐ���\��
            countText.text = "�I�u�W�F�N�g�̐�: " + objectCount.ToString();
        }
        else
        {
            Debug.LogWarning("�^�[�Q�b�g�I�u�W�F�N�g���w�肳��Ă��܂���");
        }
    }
}
