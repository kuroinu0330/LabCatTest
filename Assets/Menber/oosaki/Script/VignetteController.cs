using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume postProcessVolume;
    [SerializeField]
    private float effectDuration = 5f; // エフェクトの持続時間（秒）

    //private Vignette vignette;
    private float initialIntensity;
    private float elapsedTime = 0f; // 経過時間

    [SerializeField]
    private bool _PostWeightStart = false;
    [SerializeField]
    private float _PostWeightStartTime = 0.0f;
    private float __PostWeightStartTimeLimit = 1.0f;
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        _PostWeightStart = false;
        //postProcessVolume.profile.TryGetSettings(out vignette);
        //initialIntensity = vignette.intensity.value; // 最初の減光の強度を保存
    }

    void Update()
    {
        PostWeight();
        /*
        // 経過時間を更新
        elapsedTime += Time.deltaTime;

        // 指定した時間が経過したら減光の強度を元に戻す
        if (elapsedTime >= effectDuration)
        {
            postProcessVolume.weight = 1f; // 減光の強度を0にする（エフェクトを消す）
            enabled = false; // このスクリプトを無効にする（不要になったら更新処理を停止する）
        }
        else
        {
            // 残り時間に対する割合を計算し、それに基づいて減光の強度を減少させる
            float remainingTimeRatio = 0f + (elapsedTime / effectDuration);
            postProcessVolume.weight = initialIntensity * remainingTimeRatio;
        }
        */
    }
    private void PostWeight()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= effectDuration)
        {
            _PostWeightStart = true;
        }
        if (_PostWeightStart == true)
        {
            _PostWeightStartTime += Time.deltaTime * 0.005f;
            postProcessVolume.weight += _PostWeightStartTime;
        }
        
    }
}


