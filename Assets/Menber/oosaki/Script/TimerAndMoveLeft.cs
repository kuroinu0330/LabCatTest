using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAndMoveLeft : MonoBehaviour
{
    public float destinationX = -5.2f; // 到達すべきX座標
    private float speed; // 移動速度
    private bool shouldMove = true; // 移動フラグ
    private float initialPositionX; // オブジェクトの初期X座標
    [SerializeField]
    private float moveDistance; // 初期位置から目標位置までの距離
    private float timer = 5.0f; // 移動時間

    void Start()
    {
        initialPositionX = transform.position.x; // オブジェクトの初期X座標を取得
        moveDistance = Mathf.Abs(destinationX - initialPositionX); // 初期位置から目標位置までの距離
        speed = moveDistance / timer; // 1秒あたりの速度を計算
    }

    void Update()
    {
        if (shouldMove)
        {
            MoveToDestination();
        }
    }

    void MoveToDestination()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(destinationX, transform.position.y, transform.position.z), step);

        // 目標位置に到達したら停止
        if (Mathf.Abs(transform.position.x - initialPositionX) >= moveDistance)
        {
            shouldMove = false;
            transform.position = new Vector3(destinationX, transform.position.y, transform.position.z);
        }
    }
}