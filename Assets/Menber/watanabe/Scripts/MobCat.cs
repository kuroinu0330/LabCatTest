using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MobCat; 

public class MobCat : MonoBehaviour
{
    [SerializeField]
    MobCatMg mobCat;
    /*[SerializeField]
    Timer timer;*/
    //���R�ɓ����X�s�[�h
    [SerializeField]
    private float FreeSpeed;
    //�W�܂�Ƃ��̃X�s�[�h
    [SerializeField]
    private float GetherSpeed;
    //�W�܂�Ώ�
    [SerializeField]
    Transform target;
    //�������L�w��
    [SerializeField]
    public int num;
    //�w���obj
    [SerializeField]
    public int _PointObj1;
    [SerializeField]
    public int _PointObj2;
    public MobCatMove move;
    [SerializeField]
    private bool flag;
    [SerializeField,Header("�J�n����")]
    private float _currentTime;
    [SerializeField, Header("���b�Ԃɂ��邩")]
    private float _spanTime;
    [SerializeField, Header("�Q�[���X�^�[�g")]
    private bool isActive = false;
    //�L�̍s��
    public enum MobCatMove
    {
        Free,
        Gather,
        Sleep,
    }
    void Update()
    {
        MobCatMoveState();
        //����m�F�p�̃L�[�R�[�h
        if (Input.GetKeyDown(KeyCode.Q))
        {
            move = MobCatMove.Gather;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            move = MobCatMove.Free;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = MobCatMove.Sleep;
        }
    }
    //�X�e�[�g�����g�쓮
    public void MobCatMoveState()
    {
        switch (move)
        {
            case MobCatMove.Free:
                RandomMove();
                break;
            case MobCatMove.Gather:
                GatherMove();
                break;
            case MobCatMove.Sleep:
                SleepMove();
                break;
        }
    }
    //���̓���������
    private void RandomMove()
    {
        if (isActive == true)
        {
            if (flag == true)
            {
                transform.position = Vector3.MoveTowards(mobCat.MobCats[num].transform.position,
                                                         mobCat.PointObj1[_PointObj1].transform.position,
                                                         FreeSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(mobCat.MobCats[num].transform.position,
                                                         mobCat.PointObj2[_PointObj2].transform.position,
                                                         FreeSpeed * Time.deltaTime);
            }
        }
        Sleep();
        
    }
    //Boss�Ɍ�����
    private void GatherMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
    }
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        //�g���b�v�ɓ�����Ə�����
        if (other.gameObject.CompareTag("Trap1"))
        {
            Destroy(this.gameObject);
        }
        //�g���b�v�ɓ�����Ə�����
        if (other.gameObject.CompareTag("Trap2"))
        {
            Destroy(this.gameObject);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D�@other)
    {
        if (other.gameObject == mobCat.PointObj1[_PointObj1])
        {
            flag = false;
        }
        else if (other.gameObject == mobCat.PointObj2[_PointObj2])
        {
            flag = true;
        }
    }
    private void SleepMove()
    {
        //�тÂ��낢�̃A�j���V������Start


    }

    /// <summary>
    /// ���b�ԂÂ�10%�̊m���ŖтÂ��낢������
    /// </summary>
    private void Sleep()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _spanTime)
        {
            int Ran = Random.Range(0, 100);
            Debug.Log(Ran);
            if (Ran < 10)
            {
                Debug.Log("�퍕��");
                move.HasFlag(MobCatMove.Sleep);
            }
            _currentTime = 0;
        }
    }
}
