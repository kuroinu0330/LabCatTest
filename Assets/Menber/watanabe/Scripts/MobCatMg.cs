using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static MobCatMg;

public class MobCatMg : MonoBehaviour
{
    //�q�L�̏��
    [SerializeField]
    private GameObject Cat;
    //���������q�L�̃��X�g
    [SerializeField,Header("�q�L�̃��X�g")]
    public List<GameObject> MobCats = new List<GameObject>();
    //����̈ړ����邽�߂̃|�C���g
    [SerializeField, Header("�L�������|�C���g1")]
    public List<GameObject> PointObj1 = new List<GameObject>();
    [SerializeField, Header("�L�������|�C���g2")]
    public List<GameObject> PointObj2 = new List<GameObject>();

    // private  -> public �ɕύX 12/20 ���C
    [SerializeField, Header("�L�̐�")]
    public int MobNum;

    //�p�����܂Ƃ߂Ă�����̃I�u�W�F�N�g
    [SerializeField]
    private GameObject EmptyObject;
    [SerializeField]
    private GameObject BossCatPos;
    public void Start()
    {
    }
    public void Update()
    {
       //Invoke("CreateCat",1.0f);
    }
    private void CreateCat()
    {
        /*if (MobNum < 8)
        {
            var obj = Instantiate(Cat, new Vector3(BossCatPos.transform.position.x, 
                                                   BossCatPos.transform.position.y, 0.0f),
                                                   Quaternion.identity);
            MobCats.Add(obj);
            MobNum++;
        }*/
    }
}
