using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button yourButton; // �{�^�����A�^�b�`���邽�߂̕ϐ�
    public float cooldownTime = 3.0f; // �N�[���_�E���̎��ԁi�b�j
    public Animator cooldownAnimator; // �N�[���_�E�����̃A�j���[�^�[

    private bool isCooldown = false; // �N�[���_�E�������ǂ����������t���O

    void Start()
    {
        yourButton.onClick.AddListener(TaskOnClick); // �{�^�����N���b�N���ꂽ�Ƃ��̃��X�i�[��ǉ�
    }

    void TaskOnClick()
    {
        if (!isCooldown)
        {
            StartCoroutine(StartCooldown());
            PlayCooldownAnimation(); // �N�[���_�E�����̃A�j���[�V�������Đ����郁�\�b�h���Ăяo��
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yourButton.interactable = false; // �{�^���𖳌���

        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        yourButton.interactable = true; // �N�[���_�E����Ƀ{�^����L����
    }

    void PlayCooldownAnimation()
    {
        if (cooldownAnimator != null)
        {
            cooldownAnimator.SetTrigger("CooldownAnimationTrigger");
        }
        else
        {
            Debug.LogWarning("�N�[���_�E�����̃A�j���[�^�[���A�^�b�`����Ă��܂���");
        }
    }
}

