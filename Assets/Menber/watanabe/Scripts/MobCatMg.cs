using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MobCatMg;

public class MobCatMg : MonoBehaviour
{
    [SerializeField,Header("�q�L�̃��X�g")]
    public List<GameObject> MobCats = new List<GameObject>();
    [SerializeField, Header("�|�C���g")]
    public List<GameObject> PointObj1 = new List<GameObject>();
    [SerializeField, Header("�|�C���g�Q")]
    public List<GameObject> PointObj2 = new List<GameObject>();
}
