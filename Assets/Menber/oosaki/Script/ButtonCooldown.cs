using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button yourButton; // ボタンをアタッチするための変数
    public float cooldownTime = 3.0f; // クールダウンの時間（秒）
    public Animator cooldownAnimator; // クールダウン中のアニメーター

    private bool isCooldown = false; // クールダウン中かどうかを示すフラグ

    void Start()
    {
        yourButton.onClick.AddListener(TaskOnClick); // ボタンがクリックされたときのリスナーを追加
    }

    void TaskOnClick()
    {
        if (!isCooldown)
        {
            StartCoroutine(StartCooldown());
            PlayCooldownAnimation(); // クールダウン中のアニメーションを再生するメソッドを呼び出す
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yourButton.interactable = false; // ボタンを無効化

        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        yourButton.interactable = true; // クールダウン後にボタンを有効化
    }

    void PlayCooldownAnimation()
    {
        if (cooldownAnimator != null)
        {
            cooldownAnimator.SetTrigger("CooldownAnimationTrigger");
        }
        else
        {
            Debug.LogWarning("クールダウン中のアニメーターがアタッチされていません");
        }
    }
}

