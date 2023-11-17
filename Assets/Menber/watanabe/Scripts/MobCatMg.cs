using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static MobCatMg;

public class MobCatMg : MonoBehaviour
{
    //子猫の情報
    [SerializeField]
    private GameObject Cat;
    //生成した子猫のリスト
    [SerializeField,Header("子猫のリスト")]
    public List<GameObject> MobCats = new List<GameObject>();
    //特定の移動するためのポイント
    [SerializeField, Header("猫向かうポイント1")]
    public List<GameObject> PointObj1 = new List<GameObject>();
    [SerializeField, Header("猫向かうポイント2")]
    public List<GameObject> PointObj2 = new List<GameObject>();
    [SerializeField, Header("猫の数")]
    private int MobNum;
    //パンをまとめておく空のオブジェクト
    [SerializeField]
    private GameObject EmptyObject;
    [SerializeField]
    private GameObject BossCatPos;
    public void Start()
    {
    }
    public void Update()
    {
        InstantiateCat();
    }
    public void InstantiateCat()
    {
        /*Cat = null;
        if (MobNum < 8)
        {
            var obj = Instantiate(Cat, new Vector3(BossCatPos.transform.position.x,BossCatPos.transform.position.y, 0.0f), Quaternion.identity);
            MobCats.Add(Cat);
            MobNum++;
        }
        else
        {

        }*/

    }
}
