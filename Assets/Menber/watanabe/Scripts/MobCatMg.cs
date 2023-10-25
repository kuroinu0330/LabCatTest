using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MobCatMg;

public class MobCatMg : MonoBehaviour
{
    [SerializeField,Header("子猫のリスト")]
    public List<GameObject> MobCats = new List<GameObject>();
    [SerializeField, Header("ポイント")]
    public List<GameObject> PointObj1 = new List<GameObject>();
    [SerializeField, Header("ポイント２")]
    public List<GameObject> PointObj2 = new List<GameObject>();
}
