using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatCounter : MonoBehaviour
{
    public GameObject targetObject; // インスペクター上でオブジェクトを指定
    public Text countText;

    void Update()
    {
        if (targetObject != null)
        {
            // ターゲットとなるオブジェクトを見つけ、数を数える
            int objectCount = GameObject.FindGameObjectsWithTag(targetObject.tag).Length;

            // テキストに数を表示
            countText.text = "オブジェクトの数: " + objectCount.ToString();
        }
        else
        {
            Debug.LogWarning("ターゲットオブジェクトが指定されていません");
        }
    }
}
