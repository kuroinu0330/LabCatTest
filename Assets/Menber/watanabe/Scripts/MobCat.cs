using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCat : MonoBehaviour
{
    //public GameObject player;
    //���R�ɓ����X�s�[�h
    [SerializeField]
    private float Freespeed;
    //�W�܂�Ƃ��̃X�s�[�h
    [SerializeField]
    private float GetherSpeed;
    //�W�܂�Ώ�
    [SerializeField] 
    Transform target;
    Vector3 movePosition;
    [SerializeField]
    List<GameObject> MobCats = new List<GameObject>();
    private int num;
    public MobCatMove move;
    //private Vector3 Player_pos; //�v���C���[�̃|�W�V����
    void Start()
    {
        movePosition = moveRandomPosition(); 
    }
    public enum MobCatMove
    {
        FreeMove,
        Gather,
    }
    void Update()
    {
        MobCatMoveState();
        MoveTest();
    }
    public void MobCatMoveState()
    {
        switch (move)
        {
            case MobCatMove.FreeMove:
                RandomMove();
                break;
            case MobCatMove.Gather:
                GatherMove();
                break;
        }
    }
    //����m�F�֐�
    private void MoveTest()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            move = MobCatMove.Gather;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            move = MobCatMove.FreeMove;
        }
    }

    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(-2, 7), Random.Range(-3, 2), 5);
        return randomPosi;
    }
    private void RandomMove()
    {
        for (int i = 0; i < MobCats.Count; i ++)
        {
            if (movePosition == MobCats[i].transform.position)
            {
                movePosition = moveRandomPosition();
            }
            this.MobCats[i].transform.position = Vector3.MoveTowards(MobCats[i].transform.position, movePosition, Freespeed * Time.deltaTime);  //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x
            //Debug.Log(this.transform.position);
        }

    }
    private void GatherMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
    }


}
