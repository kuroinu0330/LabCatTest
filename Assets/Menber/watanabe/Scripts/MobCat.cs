using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static MobCat; 

public class MobCat : MonoBehaviour
{
    [SerializeField]
    MobCatMg mobCat;
    //自由に動くスピード
    [SerializeField]
    private float FreeSpeed;
    //集まるときのスピード
    [SerializeField]
    private float GetherSpeed;
    //集まる対象
    [SerializeField]
    Transform target;
    //動かす猫指定
    [SerializeField]
    public int num;
    public MobCatMove move;
    [SerializeField]
    private bool flag;
    [SerializeField,Header("開始時間")]
    private float _currentTime;
    [SerializeField, Header("何秒間にするか")]
    private float _spanTime;
    [SerializeField, Header("ゲームスタート")]
    private bool isActive = false;
    [SerializeField]
    private GameObject _bossCatPs;
    float viewX; // ビューポート座標のxの値
    float viewY; // ビューポート座標のyの値
    [SerializeField]
    public int SleepPercent;

    private Animator anim;

    [SerializeField]
    private int CatKeyCount;
    [SerializeField, Header("開始時間")]
    private float _CatcurrentTime;
    [SerializeField, Header("何秒間にするか")]
    private float _CatspanTime;
    //猫の行動
    public enum MobCatMove
    {
        Free,
        Gather,
        _Sleep,
    }
    void FixedUpdate()
    {
        MobCatMoveState();
        //動作確認用のキーコード
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CatKeyCount++;
            if (CatKeyCount == 1)
            {
                move = MobCatMove.Gather;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            move = MobCatMove.Free;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = MobCatMove._Sleep;
        }
    }
    //ステートメント駆動
    public void MobCatMoveState()
    {
        switch (move)
        {
            case MobCatMove.Free:
                RandomMove();
                FreeSpeed = 4;
                anim.SetBool("SleepBool", false);
                break;
            case MobCatMove.Gather:
                GatherMove();
                break;
            case MobCatMove._Sleep:
                SleepMove();
                break;
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen  height: " + Screen.height);
    }
    //一定の動きをする
    private void RandomMove()
    {
        if (this.gameObject.transform.position == mobCat._pointPs1[num].transform.position)
        {
            flag = false;
        }
        if (this.gameObject.transform.position == mobCat._pointPs2[num].transform.position)
        {
            flag = true;
        }
        if (isActive == true)
        {
            if (flag == true)
            {
                transform.position = Vector3.MoveTowards(mobCat.MobCats[num].transform.position,
                                                         mobCat._pointPs1[num].transform.position,
                                                         FreeSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(mobCat.MobCats[num].transform.position,
                                                         mobCat._pointPs2[num].transform.position,
                                                         FreeSpeed * Time.deltaTime);
            }
        }
        Sleep();
    }
    /*Bossに向かう*/
    private void GatherMove()
    {
        _CatcurrentTime += Time.deltaTime;
        if (_CatcurrentTime < _CatspanTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
        }
        else if (_CatcurrentTime > _CatspanTime)
        {
            move = MobCatMove.Free;
            _CatcurrentTime = 0;
            CatKeyCount = 0;
        }

    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        //トラップに当たると消える
        if (collision.gameObject.CompareTag("Trap"))
        {
            FreeSpeed = 0;
            mobCat.CatCount--;
            anim.SetBool("DeathBool", true);
            mobCat.MobCats.Remove(collision.gameObject);
            Invoke("CatDestroy", 1.3f);
        }
    }
    private void CatDestroy()
    {
        Destroy(mobCat.MobCats[num]);
    }
    private void SleepMove()
    {
        FreeSpeed = 0;
        //毛づくろいのアニメションをStart
        anim.SetBool("SleepBool",true);
        //画面外判定
        viewX = Camera.main.WorldToViewportPoint(this.gameObject.transform.position).x;
        viewY = Camera.main.WorldToViewportPoint(this.gameObject.transform.position).y;
        if (0 <= viewX && viewX >= 1 || 0 <= viewY && viewY >= 1)
        {
            Debug.Log("でた");
            move = MobCatMove.Free;
            anim.SetBool("SleepBool", false);
            FreeSpeed = 4;
        }
    }

    /// <summary>
    /// 何秒間づつに10%の確率で毛づくろいをする
    /// </summary>
    private void Sleep()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _spanTime)
        {
            int Ran = Random.Range(0, 100);
            // Debug.Log(Ran);
            if (Ran < SleepPercent)
            {
                Debug.Log("削黒い");
                move = MobCatMove._Sleep;
            }
            _currentTime = 0;
        }
    }
}
