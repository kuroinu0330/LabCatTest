using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnergyScript : MonoBehaviour
{
    // エナジーフラグ
    bool EnergyFlag = false;

    // 仮トラップ
    bool TrapFlag = false;

    // エナジーの経過時間
    float EnergyTime = 0f;

    // エナジーの効果時間
    float limitTime = 10f;

    // 猫の体力
    int CatHP = 1;

    private void Update()
    {
        CatEnergy();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            EnergyFlag = true;
            CatHP++;
        }

        if (collision.gameObject.tag == "Trap")
        {
            TrapFlag = true;
            CatHP -= 1;
        }
    }

    // 当たったら10秒カウントするまでは完成
    // トラップに当たる判定はわからないので仮作成。

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
            CatHP -= 1;
        }

        // トラップを踏んだ場合
        if(TrapFlag)
        {
            EnergyFlag = false;
            TrapFlag = false;
            EnergyTime = 0;
        }
    }
}
