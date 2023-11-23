using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGatherer : MonoBehaviour
{
    public Transform targetObject; // 集める対象のオブジェクト
    public GameObject[] objectsToGather; // 集めるオブジェクトのリスト
    public float gatheringSpeed = 5f; // オブジェクトが集まる速度

    private bool isGathering = false;

    void Update()
    {
        if (isGathering)
        {
            GatherObjects();
        }
    }

    // ボタンから呼ばれるメソッド
    public void StartGathering()
    {
        isGathering = true;
    }

    void GatherObjects()
    {
        if (targetObject != null && objectsToGather.Length > 0)
        {
            // targetObjectに向かってオブジェクトを動かす
            Vector3 targetPosition = targetObject.position;
            foreach (GameObject obj in objectsToGather)
            {
                if (obj != null)
                {
                    Vector3 moveDirection = targetPosition - obj.transform.position;
                    float distanceToTarget = moveDirection.magnitude;

                    if (distanceToTarget > 0.1f) // 目標地点に近づくまで移動
                    {
                        obj.transform.Translate(moveDirection.normalized * gatheringSpeed * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("集める対象のオブジェクトが指定されていません");
        }
    }
}
