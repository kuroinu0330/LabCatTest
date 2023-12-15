using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCat : MonoBehaviour
{

    // テスト 全体の猫を数えられる関数が必要
    [SerializeField]
    int catNum;

    [SerializeField]
    Image CatImage;

    [SerializeField] List<CatData> CatDatas;

    void Update()
    {
        CatResult();
    }

    public void CatResult()
    {
        if(catNum == 1)
        {
            CatNumber(CatData.Cat.cat1);
        }

        if (catNum == 2)
        {
            CatNumber(CatData.Cat.cat2);
        }

        if (catNum == 3)
        {
            CatNumber(CatData.Cat.cat3);
        }

        if (catNum == 4)
        {
            CatNumber(CatData.Cat.cat4);
        }

        if (catNum == 5)
        {
            CatNumber(CatData.Cat.cat5);
        }

        if (catNum == 6)
        {
            CatNumber(CatData.Cat.cat6);
        }

        if (catNum == 7)
        {
            CatNumber(CatData.Cat.cat7);
        }

        if (catNum == 8)
        {
            CatNumber(CatData.Cat.cat8);
        }
    }

    public void CatNumber(CatData.Cat cat)
    {
        CatData data = CatDatas.Find(data => data.cat == cat);
        CatImage.sprite = data.catSprite;
    }

    [System.Serializable]
    public class CatData
    {
        public enum Cat
        {
            cat1,
            cat2,
            cat3,
            cat4,
            cat5,
            cat6,
            cat7,
            cat8
        }

        public Cat cat;
        public Sprite catSprite;
    }
        
}
