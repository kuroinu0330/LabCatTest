using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60.0f; // �^�C�����~�b�g�i�b�j
    private float timer; // �^�C�}�[�̃J�E���g�_�E������
    public Text timerText; // �^�C�}�[�\���p��Text�R���|�[�l���g
    private int catCount; // �L�̐�
    public Text catCountText; // �L�̐���\������Text�R���|�[�l���g

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit; // �^�C�}�[��������
        //catCount = GameObject.FindGameObjectsWithTag("Cat").Length; // �L�̐����擾
        //UpdateCatCountDisplay(); // �L�̐���\��
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // �^�C�}�[���J�E���g�_�E��
            UpdateTimerDisplay(); // �^�C�}�[�̕\�����X�V

            if (timer <= 0)
            {
                TimerExpired(); // �^�C�}�[���[���ȉ��ɂȂ�����Q�[���N���A�����s
            }
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + timer.ToString("F1"); // �^�C�}�[�̎c�莞�Ԃ�\��
    }

    //void UpdateCatCountDisplay()
    //{
        //catCountText.text = "Cats: " + catCount; // �L�̐���\��
    //}

    void TimerExpired()
    {
        // �^�C�}�[���[���ȉ��ɂȂ����Ƃ��̃Q�[���N���A�����������ɒǉ�
    }
}
