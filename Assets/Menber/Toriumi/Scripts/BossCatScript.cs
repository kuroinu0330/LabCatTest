using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static SoundManagerTest;

public class BossCatScript : MonoBehaviour
{
    Animator anim;

    [SerializeField, Header("チャンネル")]
    private int _Channel;

    // 移動時間
    public float BossSpeed = 5f;

    Vector2 BossMovePos;

    private float _time;
    private float _timeEnd = 3;

    public int BossCatHP = 1;

    // 制限する値 Inspector上で変更
    [SerializeField]
    float   xMaxLimit,
            yMaxLimit,
            xMinLimit,
            yMinLimit;

    // これでスクロールしても変わらず制限できる
    [SerializeField]
    GameObject LimitObject;

    /* fade系 */
    [SerializeField]
    GameObject FadePanel;

    // α値の設定
    float alpha = 1f;

    /* Energy判定 */

    // エナジーフラグ
    bool EnergyFlag = false;


    // エナジーの経過時間
    float EnergyTime = 0f;

    // エナジーの効果時間
    float limitTime = 10f;

    /* ギミック判定 */

    // 仮トラップ
    bool TrapFlag = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        DeathCat();

        if (BossCatHP > 0)
        {
            BossMove();
            CatGimmick();
            CatEnergy();
        }

        if(BossCatHP < 1)
        {
            SceneChange();
        }

        _time += Time.deltaTime;

        if (_time >= _timeEnd)
        {
            int rnd = Random.Range(0, 4);
           //  SoundManagerTest.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, rnd);
            _time = 0.0f;
        }
    }

    // ボス猫の移動
    public void BossMove()
    {
        // 左クリック押すと
        if(Input.GetMouseButtonDown(0))
        {
            BossMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(BossMovePos);
        }

        // 範囲制限 この中で押さなければ反応しない
        if (BossMovePos.x == Mathf.Clamp(BossMovePos.x, LimitObject.transform.position.x + xMinLimit, LimitObject.transform.position.x + xMaxLimit) &&
            BossMovePos.y == Mathf.Clamp(BossMovePos.y, LimitObject.transform.position.y + yMinLimit, LimitObject.transform.position.y + yMaxLimit))
        {
            // ほぼ等速で動く
            transform.position = Vector2.MoveTowards(transform.position, BossMovePos, BossSpeed * Time.deltaTime);
        }
    }

    // ギミックトリガー判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Trap"))
        {
            TrapFlag = true;
        }

        if(collision.tag == ("Energy"))
        {
            EnergyFlag = true;
        }
    }

    // トラップに当たる判定はわからないので仮作成。
    public void CatGimmick()
    {
        if(TrapFlag)
        {
            BossCatHP -= 1;
            TrapFlag = false;
        }
    }

    // 当たったら10秒カウントするまでは完成
    public void CatEnergy()
    {
        // 10秒の無敵時間をカウント
        if (EnergyFlag)
        {
            EnergyTime += Time.deltaTime;
        }

        // 10秒経ったらEnergyの効果を消す。
        if (EnergyTime >= limitTime)
        {
            EnergyFlag = false;
            EnergyTime = 0;
            BossCatHP -= 1;
        }

        // トラップを踏んだ場合
        if (TrapFlag)
        {
            EnergyFlag = false;
            TrapFlag = false;
            EnergyTime = 0;
        }
    }

    // 死んだときのアニメーション
    public void DeathCat()
    {
        if (BossCatHP == 0)
        {
            anim.SetBool("DeathOn", true);
        }
    }

    // fadeOut
    public void FadeOut()
    {
        FadePanel.SetActive(true);
    }

    // フェード後のシーンチェンジ
    public void SceneChange()
    {
        if (FadePanel.GetComponent<Image>().color.a >= alpha)
        {
            Debug.Log("clear");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}


