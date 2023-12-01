using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationFPSController : MonoBehaviour
{
    [SerializeField, Range(1, 30)]
    int fps = 10;

    Animator anim;

    // �������l����
    float holdTime;

    // �X�L�b�v���ꂽ�X�V����
    float skippTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        InitializeThresholdTime();
    }
    void Update()
    {
        skippTime += Time.deltaTime;

        if(holdTime > skippTime)
        {
            return;
        }

        // �A�j���[�V�����̎��Ԃ��v�Z����B
        anim.Update(skippTime);
        skippTime = 0f;
    }

    // �������l���Ԃ̏�����
    void InitializeThresholdTime()
    {
        holdTime = 1f / fps;
    }

    // Inspector�̒l�̕ύX���̏���
    private void OnValidate()
    {
        InitializeThresholdTime();
    }
}
