using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    [SerializeField]
    private int _countMap;
    private bool _ActiveMap = true;
    [SerializeField]
    private float _timer = 0;
    [SerializeField]
    private float _endTime;

    void Start()
    {
        // 背景画像のx座標
        startpos = transform.position.x;
        // 背景画像のx軸方向の幅
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen  height: " + Screen.height);
    }

    private void FixedUpdate()
    {
        if (_ActiveMap == true)
        {
            ScrollMap();
        }

    }
    private void ScrollMap()
    {
        _timer += Time.deltaTime;
        if (_timer >= _endTime)
        {
            _ActiveMap = false;
        }

        // 無限スクロールに使用するパラメーター
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // 背景の視差効果に使用するパラメーター
        float dist = (cam.transform.position.x * parallaxEffect);

        // 視差効果を与える処理
        // 背景画像のx座標をdistの分移動させる
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + length)
        {
            _countMap++;
        }
        else if (temp < startpos - length)
        {
            _countMap++;
        }
        // 無限スクロール
        // 画面外になったら背景画像を移動させる
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
