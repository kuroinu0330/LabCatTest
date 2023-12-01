using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationFPSController : MonoBehaviour
{
    [SerializeField, Range(1, 30)]
    int fps = 10;

    Animator anim;

    // しきい値時間
    float holdTime;

    // スキップされた更新時間
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

        // アニメーションの時間を計算する。
        anim.Update(skippTime);
        skippTime = 0f;
    }

    // しきい値時間の初期化
    void InitializeThresholdTime()
    {
        holdTime = 1f / fps;
    }

    // Inspectorの値の変更時の処理
    private void OnValidate()
    {
        InitializeThresholdTime();
    }
}
