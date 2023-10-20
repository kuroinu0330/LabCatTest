using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobCatTest : MonoBehaviour
{
    [SerializeField]
    MobCat mobCat;
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
    [SerializeField]
    public int num;
    [SerializeField]
    public int i;
    [SerializeField]
    public int a;
    public MobCatMove move;
    [SerializeField]
    private bool flag;
    public enum MobCatMove
    {
        Free,
        Gather,
        sleep,
    }
    private void Start()
    {
        //if (this == null) { }
    }

    void Update()
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
        for (int num = 0; num < mobCat.MobCats.Count; num++)
        {
            switch (num)
            {
                #region 子猫たちの動き
                case 0:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[0].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[1].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    break;
                case 1:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[2].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[3].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    break;
                case 2:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[4].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[5].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    //Debug.Log("3号");
                    break;
                case 3:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[6].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[7].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    //Debug.Log("4号");
                    break;
                case 4:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[8].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[9].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    //Debug.Log("5号");
                    break;
                case 5:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[10].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[11].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    //Debug.Log("6号");
                    break;
                case 6:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[12].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[13].transform.position, FreeSpeed * Time.deltaTime);
                    }
                    //Debug.Log("7号");
                    break;
                case 7:
                    if (flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[14].transform.position, FreeSpeed * Time.deltaTime);
                    }

                    else if (!flag)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, mobCat.PointObj[15].transform.position, FreeSpeed * Time.deltaTime);
                    }
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == mobCat.PointObj[i])
        {
            flag = false;
        }
        else if (other.gameObject == mobCat.PointObj[a])
        {
            flag = true;
        }

    }
}
