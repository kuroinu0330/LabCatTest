using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCatTestMove : MonoBehaviour
{
    // 移動時間
    public float _BossSpeed = 5f;

    Vector2 _BossMovePos;
    private Animator anim;
    public bool isActive = false;
    private void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (isActive)
        {
            BossMoves();
        }
    }

    // ボス猫の移動
    public void BossMoves()
    {
        //Debug.Log("開始");
        // 左クリック押すと
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(_BossMovePos);
            // スクリーン座標をワールド座標に変換
            _BossMovePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        // ほぼ等速で動く
        transform.position = Vector2.MoveTowards(transform.position, _BossMovePos, _BossSpeed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, _BossMovePos, _BossSpeed * Time.deltaTime);

    }
    public void ActiveFalse()
    {
        isActive = false;
    }
}
