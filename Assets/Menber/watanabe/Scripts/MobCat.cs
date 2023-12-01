using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    private void RandomMove()
    {
        /*if (flag)
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
        */
    }
    private void GatherMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == mobCat.PointObj1[_PointObj1])
        {
            flag = false;
        }
        else if (other.gameObject == mobCat.PointObj2[_PointObj2])
        {
            flag = true;
        }
    }*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap1"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Trap2"))
        {
            Destroy(this.gameObject);
        }
    }
    private void SleepMove()
    {
        RandomMove();
        _currentTime += Time.deltaTime;
        if (_currentTime > _spanTime)
        {
            int Ran = Random.Range(0, 100);
            Debug.Log(Ran);
            if (Ran < 10)
            {
                Debug.Log("�Q�邩�ȁH");

                _currentTime = 0f;
            }

        }

    }

}
