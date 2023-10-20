using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MobCatMg;

public class MobCatMg : MonoBehaviour
{
    //子猫のリスト
    public List<GameObject> MobCats = new List<GameObject>();
    //特定の移動するためのポイント
    public List<GameObject> PointObj1 = new List<GameObject>();
    public List<GameObject> PointObj2 = new List<GameObject>();
}
