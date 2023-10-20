using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCatTest : MonoBehaviour
{
    //子猫のリスト
    public List<GameObject> MobCats = new List<GameObject>();
    //特定の移動するためのポイント
    public List<GameObject> PointObj = new List<GameObject>();
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    //自由に動くスピード
    [SerializeField]
    private float FreeSpeed;
    //集まるときのスピード
    [SerializeField]
    private float GetherSpeed;
    //集まる対象
    
    [SerializeField]
    Transform target;
    Vector3 movePosition;
    public int num;
    public MobCatMove move;
    private Vector3 Player_pos; //プレイヤーのポジション

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
                    #region 子猫たちの動き
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
                        //Debug.Log("2号");
                        break;
                    case 2:
                        //Debug.Log("3号");
                        break;
                    case 3:
                        //Debug.Log("4号");
                        break;
                    case 4:
                        //Debug.Log("5号");
                        break;
                    case 5:
                        //Debug.Log("6号");
                        break;
                    case 6:
                        //Debug.Log("7号");
                        break;
                    case 7:
                        //Debug.Log("8号");
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
