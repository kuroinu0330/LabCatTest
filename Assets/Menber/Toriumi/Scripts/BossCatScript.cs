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

            // スクリーン座標をワールド座標に変換
            /*if (BossMovePos.x < 600.0f * Screen.currentResolution.width && BossMovePos.y > 260.0f * Screen.currentResolution.height)
            {
                BossMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }*/
            BossMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(BossMovePos);
        }

        // ほぼ等速で動く
        transform.position = Vector2.MoveTowards(transform.position, BossMovePos, BossSpeed * Time.deltaTime);
    }
}


