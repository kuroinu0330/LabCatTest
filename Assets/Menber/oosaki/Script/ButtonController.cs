using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    // オブジェクトのリスト。ボタンがクリックされたときにこれらのオブジェクトがターゲットに向かって移動します。
    public List<GameObject> objectsToMove;

    // 移動先のオブジェクト
    public GameObject targetObject;

    // オブジェクトの移動速度
    public float moveSpeed = 5f;

    // クールダウン時間
    public float cooldownTime = 3f;

    // ボタンが非アクティブな時のスプライト
    public Sprite inactiveSprite;

    // ボタンがアクティブな時のスプライト
    public Sprite activeSprite;

    // クールダウンを表示するためのイメージ
    public Image cooldownImage;

    // オブジェクトのスプライトを格納するための配列
    private Image[] objectImages;

    // クールダウン中かどうかを示すフラグ
    private bool isCooldown = false;

    // クールダウンが終了したかどうかのフラグ
    private bool cooldownEnded = false;

    // インスタンスが生成されたときに最初に呼ばれるメソッド
    private void Start()
    {
        // objectImagesの配列を初期化する
        objectImages = new Image[objectsToMove.Count];

        // 各オブジェクトにImageがアタッチされているか確認し、なければ追加する
        for (int i = 0; i < objectsToMove.Count; i++)
        {
            Image image = objectsToMove[i].GetComponent<Image>();

            if (image == null)
                image = objectsToMove[i].AddComponent<Image>();

            // objectImagesにImageを追加
            objectImages[i] = image;
        }

        // クールダウンイメージを非表示にする
        cooldownImage.gameObject.SetActive(false);
    }

    // 毎フレーム呼ばれるメソッド
    private void Update()
    {

        // クールダウン中なら何もしない
        if (isCooldown)
            return;

        // クールダウンが終了していればQキーが押されたかどうかを確認
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // クールダウンを開始
            StartCoroutine(StartCooldown());
        }

        
       

        // マウスの左ボタンがクリックされたとき
        //if (Input.GetMouseButtonDown(0))
        {
            // クールダウンを開始
            //StartCoroutine(StartCooldown());
        }
    }

    // オブジェクトを移動するコルーチン
    IEnumerator MoveObject(GameObject obj)
    {
        // オブジェクトがターゲットに到達するまで繰り返す
        while (Vector3.Distance(obj.transform.position, targetObject.transform.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    // クールダウンを開始するコルーチン
    IEnumerator StartCooldown()
    {
        // ボタンのスプライトを非アクティブなスプライトに変更
        GetComponent<Image>().sprite = inactiveSprite;

        // クールダウン中フラグを立てる
        isCooldown = true;

        // クールダウンイメージを表示する
        cooldownImage.gameObject.SetActive(true);

        // 全てのオブジェクトのスプライトを非アクティブなスプライトに変更
        foreach (Image image in objectImages)
        {
            image.sprite = inactiveSprite;
        }

        // クールダウンの経過時間を計測するタイマー
        float timer = 0f;

        // クールダウン時間まで繰り返す
        while (timer < cooldownTime)
        {
            // クールダウンイメージの表示を更新
            cooldownImage.fillAmount = timer / cooldownTime;

            // タイマーを増やす
            timer += Time.deltaTime;

            // 1フレーム待つ
            yield return null;
        }

        // クールダウンが終わったらフラグを戻す
        isCooldown = false;

        // クールダウンイメージを非表示にする
        cooldownImage.gameObject.SetActive(false);

        // 全てのオブジェクトのスプライトをアクティブなスプライトに変更
        foreach (Image image in objectImages)
        {
            // 非アクティブなスプライトでない場合に変更
            if (image.sprite != inactiveSprite)
            {
                image.sprite = activeSprite;
            }
        }

        // ボタンのスプライトをアクティブなスプライトに変更
        GetComponent<Image>().sprite = activeSprite;

        // クールダウンが終了したことをフラグで示す
        cooldownEnded = true;
    }
}