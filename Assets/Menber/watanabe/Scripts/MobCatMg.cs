using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MobCatMg : MonoBehaviour
{
    //�q�L�̏��
    [SerializeField]
    private GameObject Cat;
    //���������q�L�̃��X�g
    [SerializeField,Header("�q�L�̃��X�g")]
    public List<GameObject> MobCats = new List<GameObject>();
    // private  -> public �ɕύX 12/20 ���C
    [SerializeField, Header("�L�̐�")]
    public int MobNum;

    //�p�����܂Ƃ߂Ă�����̃I�u�W�F�N�g
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
        // �C���X�^���X����`����Ă��Ȃ����Ɉȉ��̏��������s
        if (instance == null)
        {
            // �C���X�^���X���X�V
            instance = this;

            // �V�[���Ԃ������z���p�ɕی�
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
