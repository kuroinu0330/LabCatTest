using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MobCat;

public class MobCat : MonoBehaviour
{
    //子猫のリスト
    public List<GameObject> MobCats = new List<GameObject>();
    //特定の移動するためのポイント
    public List<GameObject> PointObj = new List<GameObject>();
}
