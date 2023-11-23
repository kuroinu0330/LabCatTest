using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCatTestMove : MonoBehaviour
{
    // �ړ�����
    public float _BossSpeed = 5f;

    Vector2 _BossMovePos;
    private Animator anim;
    public bool isActive = false;
    private void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (isActive)
        {
            BossMoves();
        }
    }

    // �{�X�L�̈ړ�
    public void BossMoves()
    {
        //Debug.Log("�J�n");
        // ���N���b�N������
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(_BossMovePos);
            // �X�N���[�����W�����[���h���W�ɕϊ�
            _BossMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        // �قړ����œ���
        transform.position = Vector2.MoveTowards(transform.position, _BossMovePos, _BossSpeed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, _BossMovePos, _BossSpeed * Time.deltaTime);

    }
    public void ActiveFalse()
    {
        isActive = false;
    }
}
