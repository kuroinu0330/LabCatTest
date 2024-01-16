using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static MobCat; 

public class MobCat : MonoBehaviour
{
    [SerializeField]
    MobCatMg mobCat;
    //���R�ɓ����X�s�[�h
    [SerializeField]
    private float FreeSpeed;
    //�W�܂�Ƃ��̃X�s�[�h
    [SerializeField]
    private float GetherSpeed;
    //�W�܂�Ώ�
    [SerializeField]
    Transform target;
    //�������L�w��
    [SerializeField]
    public int num;
    public MobCatMove move;
    [SerializeField]
    private bool flag;
    [SerializeField,Header("�J�n����")]
    private float _currentTime;
    [SerializeField, Header("���b�Ԃɂ��邩")]
    private float _spanTime;
    [SerializeField, Header("�Q�[���X�^�[�g")]
    private bool isActive = false;
    [SerializeField]
    private GameObject _bossCatPs;
    float viewX; // �r���[�|�[�g���W��x�̒l
    float viewY; // �r���[�|�[�g���W��y�̒l
    [SerializeField]
    public int SleepPercent;

    private Animator anim;

    [SerializeField]
    private int CatKeyCount;
    [SerializeField, Header("�J�n����")]
    private float _CatcurrentTime;
    [SerializeField, Header("���b�Ԃɂ��邩")]
    private float _CatspanTime;
    //�L�̍s��
    public enum MobCatMove
    {
        Free,
        Gather,
        _Sleep,
    }
    void FixedUpdate()
    {
        MobCatMoveState();
        //����m�F�p�̃L�[�R�[�h
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CatKeyCount++;
            if (CatKeyCount == 1)
            {
                move = MobCatMove.Gather;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            move = MobCatMove.Free;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = MobCatMove._Sleep;
        }
    }
    //�X�e�[�g�����g�쓮
    public void MobCatMoveState()
    {
        switch (move)
        {
            case MobCatMove.Free:
                RandomMove();
                FreeSpeed = 4;
                anim.SetBool("SleepBool", false);
                break;
            case MobCatMove.Gather:
                GatherMove();
                break;
            case MobCatMove._Sleep:
                SleepMove();
                break;
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen  height: " + Screen.height);
    }
    //���̓���������
    private void RandomMove()
    {
        if (this.gameObject.transform.position == mobCat._pointPs1[num].transform.position)
        {
            flag = false;
        }
        if (this.gameObject.transform.position == mobCat._pointPs2[num].transform.position)
        {
            flag = true;
        }
        if (isActive == true)
        {
            if (flag == true)
            {
                transform.position = Vector3.MoveTowards(mobCat.MobCats[num].transform.position,
                                                         mobCat._pointPs1[num].transform.position,
                                                         FreeSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(mobCat.MobCats[num].transform.position,
                                                         mobCat._pointPs2[num].transform.position,
                                                         FreeSpeed * Time.deltaTime);
            }
        }
        Sleep();
    }
    /*Boss�Ɍ�����*/
    private void GatherMove()
    {
        _CatcurrentTime += Time.deltaTime;
        if (_CatcurrentTime < _CatspanTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, GetherSpeed * Time.deltaTime);
        }
        else if (_CatcurrentTime > _CatspanTime)
        {
            move = MobCatMove.Free;
            _CatcurrentTime = 0;
            CatKeyCount = 0;
        }

    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        //�g���b�v�ɓ�����Ə�����
        if (collision.gameObject.CompareTag("Trap"))
        {
            FreeSpeed = 0;
            mobCat.CatCount--;
            anim.SetBool("DeathBool", true);
            mobCat.MobCats.Remove(collision.gameObject);
            Invoke("CatDestroy", 1.3f);
        }
    }
    private void CatDestroy()
    {
        Destroy(mobCat.MobCats[num]);
    }
    private void SleepMove()
    {
        FreeSpeed = 0;
        //�тÂ��낢�̃A�j���V������Start
        anim.SetBool("SleepBool",true);
        //��ʊO����
        viewX = Camera.main.WorldToViewportPoint(this.gameObject.transform.position).x;
        viewY = Camera.main.WorldToViewportPoint(this.gameObject.transform.position).y;
        if (0 <= viewX && viewX >= 1 || 0 <= viewY && viewY >= 1)
        {
            Debug.Log("�ł�");
            move = MobCatMove.Free;
            anim.SetBool("SleepBool", false);
            FreeSpeed = 4;
        }
    }

    /// <summary>
    /// ���b�ԂÂ�10%�̊m���ŖтÂ��낢������
    /// </summary>
    private void Sleep()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _spanTime)
        {
            int Ran = Random.Range(0, 100);
            // Debug.Log(Ran);
            if (Ran < SleepPercent)
            {
                Debug.Log("�퍕��");
                move = MobCatMove._Sleep;
            }
            _currentTime = 0;
        }
    }
}
