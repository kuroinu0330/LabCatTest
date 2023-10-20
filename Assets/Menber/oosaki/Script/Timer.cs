using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 10.0f; // タイムリミット（秒）
    private float timer; // タイマーのカウントダウン時間
    public Text timerText; // タイマー表示用のTextコンポーネント
    private int catCount; // 猫の数
    public Text catCountText; // 猫の数を表示するTextコンポーネント
    public Image timeBar; // タイムバー用のImageコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit; // タイマーを初期化
    //    catCount = GameObject.FindGameObjectsWithTag("Cat").Length; // 猫の数を取得
    //    UpdateCatCountDisplay(); // 猫の数を表示
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // タイマーをカウントダウン
            UpdateTimerDisplay(); // タイマーの表示を更新

            if (timer <= 0)
            {
                TimerExpired(); // タイマーがゼロ以下になったらゲームクリアを実行
            }

            // タイムバーの表示を更新
            UpdateTimeBar();
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + timer.ToString("F1"); // タイマーの残り時間を表示
    }

    //void UpdateCatCountDisplay()
    //{
    //    catCountText.text = "Cats: " + catCount; // 猫の数を表示
    //}

    void TimerExpired()
    {
        // タイマーがゼロ以下になったときのゲームクリア処理をここに追加
    }

    void UpdateTimeBar()
    {
        // タイムバーの表示を更新
        float fillAmount = timer / timeLimit; // タイムバーの長さを計算
        timeBar.fillAmount = fillAmount; // タイムバーの表示を更新
    }
}