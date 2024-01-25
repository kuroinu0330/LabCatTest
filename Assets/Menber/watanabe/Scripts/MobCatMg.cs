using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MobCatMg : MonoBehaviour
{
    //子猫の情報
    [SerializeField]
    private GameObject Cat;
    //生成した子猫のリスト
    [SerializeField,Header("子猫のリスト")]
    public List<GameObject> MobCats = new List<GameObject>();
    // private  -> public に変更 12/20 鳥海
    [SerializeField, Header("猫の数")]
    public int MobNum;

    //パンをまとめておく空のオブジェクト
    [SerializeField]
    private GameObject EmptyObject;
    [SerializeField]
    private GameObject BossCatPos;

    [SerializeField]
    public List<Transform> _pointPs1 = new List<Transform>();
    [SerializeField]
    public List<Transform> _pointPs2 = new List<Transform>();

    [SerializeField]
    public int CatCount;
    [SerializeField]
    public Text CatCountText;
    public void Start()
    {
        CatCount = 7;
    }
    public static MobCatMg instance;
    public void Awake()
    {
        // インスタンスが定義されていない時に以下の処理を実行
        if (instance == null)
        {
            // インスタンスを更新
            instance = this;

            // シーン間を持ち越す用に保護
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void Update()
    {
        //CatCountText.text = CatCount.ToString();
        if (_pointPs1 == null) return;
        if (_pointPs2 == null) return;
        if (MobCats == null) return;
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
