using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGatherer : MonoBehaviour
{
    public Transform targetObject; // �W�߂�Ώۂ̃I�u�W�F�N�g
    public GameObject[] objectsToGather; // �W�߂�I�u�W�F�N�g�̃��X�g
    public float gatheringSpeed = 5f; // �I�u�W�F�N�g���W�܂鑬�x
    public float cooldownTime = 2f; // �N�[���_�E������

    private bool isGathering = false;
    private bool cooldown = false;
    private float cooldownTimer = 0f;

    void Update()
    {
        if (isGathering)
        {
            GatherObjects();
        }

        if (cooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownTime)
            {
                cooldown = false;
                cooldownTimer = 0f;
            }
        }
    }

    // �{�^������Ă΂�郁�\�b�h
    public void StartGathering()
    {
        if (!cooldown)
        {
            isGathering = true;
        }
    }

    void GatherObjects()
    {
        if (targetObject != null && objectsToGather.Length > 0)
        {
            // targetObject�Ɍ������ăI�u�W�F�N�g�𓮂���
            Vector3 targetPosition = targetObject.position;
            bool allObjectsAtTarget = true;

            foreach (GameObject obj in objectsToGather)
            {
                if (obj != null)
                {
                    Vector3 moveDirection = targetPosition - obj.transform.position;
                    float distanceToTarget = moveDirection.magnitude;

                    if (distanceToTarget > 0.1f) // �ڕW�n�_�ɋ߂Â��܂ňړ�
                    {
                        allObjectsAtTarget = false;
                        obj.transform.Translate(moveDirection.normalized * gatheringSpeed * Time.deltaTime);
                    }
                }
            }

            if (allObjectsAtTarget)
            {
                isGathering = false;
                cooldown = true;
            }
        }
        else
        {
            Debug.LogWarning("�W�߂�Ώۂ̃I�u�W�F�N�g���w�肳��Ă��܂���");
        }
    }
}
