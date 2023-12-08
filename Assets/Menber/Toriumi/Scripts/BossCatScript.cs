using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManagerTest;

public class BossCatScript : MonoBehaviour
{
    [SerializeField, Header("チャンネル")]
    private int _Channel;
    // 移動時間
    public float BossSpeed = 5f;

    Vector2 BossMovePos;

    private float _time;
    private float _timeEnd = 3;

    // 制限する値 Inspector上で変更
    [SerializeField]
    float   xMaxLimit,
            yMaxLimit,
            xMinLimit,
            yMinLimit;

    // これでスクロールしても変わらず制限できる
    [SerializeField]
    GameObject LimitObject;
    
    void Update()
    {
        BossMove();
        _time += Time.deltaTime;
        if (_time >= _timeEnd)
        {
            int rnd = Random.Range(0, 4);
            SoundManagerTest.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, rnd);
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
}


