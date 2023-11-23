using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGatherer : MonoBehaviour
{
    public Transform targetObject; // �W�߂�Ώۂ̃I�u�W�F�N�g
    public GameObject[] objectsToGather; // �W�߂�I�u�W�F�N�g�̃��X�g
    public float gatheringSpeed = 5f; // �I�u�W�F�N�g���W�܂鑬�x

    private bool isGathering = false;

    void Update()
    {
        if (isGathering)
        {
            GatherObjects();
        }
    }

    // �{�^������Ă΂�郁�\�b�h
    public void StartGathering()
    {
        isGathering = true;
    }

    void GatherObjects()
    {
        if (targetObject != null && objectsToGather.Length > 0)
        {
            // targetObject�Ɍ������ăI�u�W�F�N�g�𓮂���
            Vector3 targetPosition = targetObject.position;
            foreach (GameObject obj in objectsToGather)
            {
                if (obj != null)
                {
                    Vector3 moveDirection = targetPosition - obj.transform.position;
                    float distanceToTarget = moveDirection.magnitude;

                    if (distanceToTarget > 0.1f) // �ڕW�n�_�ɋ߂Â��܂ňړ�
                    {
                        obj.transform.Translate(moveDirection.normalized * gatheringSpeed * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("�W�߂�Ώۂ̃I�u�W�F�N�g���w�肳��Ă��܂���");
        }
    }
}
