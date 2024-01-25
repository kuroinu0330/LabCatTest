using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAndMoveLeft : MonoBehaviour
{
    public float destinationX = -5.2f; // ���B���ׂ�X���W
    private float speed; // �ړ����x
    private bool shouldMove = true; // �ړ��t���O
    private float initialPositionX; // �I�u�W�F�N�g�̏���X���W
    [SerializeField]
    private float moveDistance; // �����ʒu����ڕW�ʒu�܂ł̋���
    private float timer = 5.0f; // �ړ�����

    void Start()
    {
        initialPositionX = transform.position.x; // �I�u�W�F�N�g�̏���X���W���擾
        moveDistance = Mathf.Abs(destinationX - initialPositionX); // �����ʒu����ڕW�ʒu�܂ł̋���
        speed = moveDistance / timer; // 1�b������̑��x���v�Z
    }

    void Update()
    {
        if (shouldMove)
        {
            MoveToDestination();
        }
    }

    void MoveToDestination()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(destinationX, transform.position.y, transform.position.z), step);

        // �ڕW�ʒu�ɓ��B�������~
        if (Mathf.Abs(transform.position.x - initialPositionX) >= moveDistance)
        {
            shouldMove = false;
            transform.position = new Vector3(destinationX, transform.position.y, transform.position.z);
        }
    }
}