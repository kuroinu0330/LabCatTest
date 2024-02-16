using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{

    // �I�u�W�F�N�g�̈ړ����x
    public float moveSpeed = 5f;

    // �N�[���_�E������
    public float cooldownTime = 8f;

    // �{�^������A�N�e�B�u�Ȏ��̃X�v���C�g
    public Sprite inactiveSprite;

    // �{�^�����A�N�e�B�u�Ȏ��̃X�v���C�g
    public Sprite activeSprite;

    // �N�[���_�E����\�����邽�߂̃C���[�W
    public Image cooldownImage;

    // �I�u�W�F�N�g�̃X�v���C�g���i�[���邽�߂̔z��
    [SerializeField]
    private Image[] objectImages;

    // �N�[���_�E�������ǂ����������t���O
    public bool isCooldown = false;


    // �N�[���_�E�����I���������ǂ����̃t���O
    private bool cooldownEnded = false;
    //�C���X�^���X�����L���@by�n�
    public static ButtonController instance;
    private void Awake()
    {
        // �C���X�^���X����`����Ă��Ȃ����Ɉȉ��̏��������s
        if (instance == null)
        {
            // �C���X�^���X���X�V
            instance = this;
        }
    }
    // �C���X�^���X���������ꂽ�Ƃ��ɍŏ��ɌĂ΂�郁�\�b�h
    private void Start()
    {

        // �N�[���_�E���C���[�W���\���ɂ���
        cooldownImage.gameObject.SetActive(false);
    }

    // ���t���[���Ă΂�郁�\�b�h
    private void Update()
    {

        // �N�[���_�E�����Ȃ牽�����Ȃ�
        if (isCooldown)
            return;

        // �N�[���_�E�����I�����Ă����Q�L�[�������ꂽ���ǂ������m�F
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // �N�[���_�E�����J�n
            StartCoroutine(StartCooldown());
        }
    }


    // �N�[���_�E�����J�n����R���[�`��
    IEnumerator StartCooldown()
    {
        // �{�^���̃X�v���C�g���A�N�e�B�u�ȃX�v���C�g�ɕύX
        GetComponent<Image>().sprite = inactiveSprite;

        // �N�[���_�E�����t���O�𗧂Ă�
        isCooldown = true;

        // �N�[���_�E���C���[�W��\������
        cooldownImage.gameObject.SetActive(true);

        // �S�ẴI�u�W�F�N�g�̃X�v���C�g���A�N�e�B�u�ȃX�v���C�g�ɕύX
        foreach (Image image in objectImages)
        {
            image.sprite = inactiveSprite;
        }

        // �N�[���_�E���̌o�ߎ��Ԃ��v������^�C�}�[
        float timer = 0f;
        // �N�[���_�E�����Ԃ܂ŌJ��Ԃ�
        while (timer < cooldownTime)
        {
            // �N�[���_�E���C���[�W�̕\�����X�V
            cooldownImage.fillAmount = timer / cooldownTime;

            // �^�C�}�[�𑝂₷
            timer += Time.deltaTime;

            // 1�t���[���҂�
            yield return null;
        }

        // �N�[���_�E�����I�������t���O��߂�
        isCooldown = false;

        // �N�[���_�E���C���[�W���\���ɂ���
        cooldownImage.gameObject.SetActive(false);

        // �S�ẴI�u�W�F�N�g�̃X�v���C�g���A�N�e�B�u�ȃX�v���C�g�ɕύX
        foreach (Image image in objectImages)
        {
            // ��A�N�e�B�u�ȃX�v���C�g�łȂ��ꍇ�ɕύX
            if (image.sprite != inactiveSprite)
            {
                image.sprite = activeSprite;
            }
        }

        // �{�^���̃X�v���C�g���A�N�e�B�u�ȃX�v���C�g�ɕύX
        GetComponent<Image>().sprite = activeSprite;

        // �N�[���_�E�����I���������Ƃ��t���O�Ŏ���
        cooldownEnded = true;
    }
}