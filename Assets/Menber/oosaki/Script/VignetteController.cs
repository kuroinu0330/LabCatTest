using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public float effectDuration = 5f; // エフェクトの持続時間（秒）

    private Vignette vignette;
    private float initialIntensity;
    private float elapsedTime = 0f; // 経過時間

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        initialIntensity = vignette.intensity.value; // 最初の減光の強度を保存
    }

    void Update()
    {
        // 経過時間を更新
        elapsedTime += Time.deltaTime;

        // 指定した時間が経過したら減光の強度を元に戻す
        if (elapsedTime >= effectDuration)
        {
            vignette.intensity.value = 0f; // 減光の強度を0にする（エフェクトを消す）
            enabled = false; // このスクリプトを無効にする（不要になったら更新処理を停止する）
        }
        else
        {
            // 残り時間に対する割合を計算し、それに基づいて減光の強度を減少させる
            float remainingTimeRatio = 1f - (elapsedTime / effectDuration);
            vignette.intensity.value = initialIntensity * remainingTimeRatio;
        }
    }
}


