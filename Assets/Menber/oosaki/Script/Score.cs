using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float timeLimit = 60.0f; // タイムリミット（秒）
    private float timer; // タイマーのカウントダウン時間
    public Text timerText; // タイマー表示用のTextコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit; // タイマーを初期化
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
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + timer.ToString("F1"); // タイマーの残り時間を表示
    }

    void TimerExpired()
    {
        // タイマーがゼロ以下になったときのゲームクリア処理をここに追加
    }
}
