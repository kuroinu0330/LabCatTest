using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCatScript : MonoBehaviour
{
    // 移動時間
    public float BossSpeed = 5f;

    Vector2 BossMovePos;

    void Update()
    {
        BossMove();
    }

    // ボス猫の移動
    public void BossMove()
    {
        // 左クリック押すと
        if(Input.GetMouseButtonDown(0))
        {
            // スクリーン座標をワールド座標に変換
            BossMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // ほぼ等速で動く
        transform.position = Vector2.MoveTowards(transform.position, BossMovePos, BossSpeed * Time.deltaTime);
    }
}


