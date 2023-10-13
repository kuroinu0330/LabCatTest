using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCatTest : MonoBehaviour
{
    public List<GameObject> MobCats = new List<GameObject>();
    //���R�ɓ����X�s�[�h
    [SerializeField]
    private float FreeSpeed;
    //�W�܂�Ƃ��̃X�s�[�h
    [SerializeField]
    private float GetherSpeed;
    //�W�܂�Ώ�
    #region�@�L�͈̔�
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform targetx;
    [SerializeField]
    Transform target1;
    [SerializeField]
    Transform target2;
    #endregion

    [SerializeField] 
    private Transform _LeftEdge;
    [SerializeField] 
    private Transform _RightEdge;
    Vector3 movePosition;
    public int num = 1;
    public MobCatMove move;
    private Vector3 Player_pos; //�v���C���[�̃|�W�V����
    void Start()
    {
        //movePosition = moveRandomPosition();
    }
    public enum MobCatMove
    {
        FreeMove,
        Gather,
        sleep,
    }


    void FixedUpdate()
    {
        MobCatMoveState();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            move = MobCatMove.Gather;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            move = MobCatMove.FreeMove;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = MobCatMove.sleep;
        }
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
            case MobCatMove.sleep:

                break;
        }
    }


    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(target.position.x, targetx.position.x), 
                                        Random.Range(target1.position.y, target2.position.y));
                                        return randomPosi;
    }
    private void RandomMove()
    {
        if (transform.position.x >= _RightEdge.position.x)
        {
             transform.position = Vector3.MoveTowards(transform.position, target.position, FreeSpeed * Time.deltaTime);
        }
        if (transform.position.x <= _LeftEdge.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, FreeSpeed * Time.deltaTime);
        }
        /*if (movePosition == player.transform.position)
        {
            movePosition = moveRandomPosition();
        }
        this.player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, FreeSpeed * Time.deltaTime);  //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x
        Debug.Log(this.transform.position);*/

    }
    private void GatherMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
    }
}
