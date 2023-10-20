using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCatTest : MonoBehaviour
{
    //�q�L�̃��X�g
    public List<GameObject> MobCats = new List<GameObject>();
    //����̈ړ����邽�߂̃|�C���g
    public List<GameObject> PointObj = new List<GameObject>();
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    //���R�ɓ����X�s�[�h
    [SerializeField]
    private float FreeSpeed;
    //�W�܂�Ƃ��̃X�s�[�h
    [SerializeField]
    private float GetherSpeed;
    //�W�܂�Ώ�
    
    [SerializeField]
    Transform target;
    Vector3 movePosition;
    public int num;
    public MobCatMove move;
    private Vector3 Player_pos; //�v���C���[�̃|�W�V����

    private int direction = 1;
    private bool flag;


    void Start()
    {
        //movePosition = moveRandomPosition();
    }
    public enum MobCatMove
    {
        Free,
        Gather,
        sleep,
    }
    private void Update()
    {
        
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
            move = MobCatMove.Free;
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
            case MobCatMove.Free:
                RandomMove();
                break;
            case MobCatMove.Gather:
                GatherMove();
                break;
            case MobCatMove.sleep:
                break;
        }
    }
    private void RandomMove()
    {
        for (int num = 0; num < MobCats.Count; num++)
        {
            switch (num)
            {
                    #region �q�L�����̓���
                    case 0:
                    if (flag)
                    {

                        transform.position = Vector3.MoveTowards(transform.position, PointObj[0].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {

                        transform.position = Vector3.MoveTowards(transform.position, PointObj[1].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    break;
                case 1:
                        //Debug.Log("2��");
                        break;
                    case 2:
                        //Debug.Log("3��");
                        break;
                    case 3:
                        //Debug.Log("4��");
                        break;
                    case 4:
                        //Debug.Log("5��");
                        break;
                    case 5:
                        //Debug.Log("6��");
                        break;
                    case 6:
                        //Debug.Log("7��");
                        break;
                    case 7:
                        //Debug.Log("8��");
                        break;
                        #endregion
                }
            

        }

    }
    private void GatherMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PointObj[0])
        {

            flag = true;
        }

        else if (other.gameObject == PointObj[1])
        {

            flag = false;
        }
    }
}
