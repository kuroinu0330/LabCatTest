using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTest : MonoBehaviour
{
    Object.Stage.BackGround backGround;

    private void Start()
    {
        backGround = new Object.Stage.BackGround(
            GetComponent<SpriteRenderer>(), // 背景画像
            Camera.main, // 基準となるカメラ
            1 // [赤白][赤白][赤白][赤白] と4回繰り返しているので4。画像の大きさと相談しながら調整する。
        );
    }

    private void LateUpdate()
    {
        // カメラ位置と現在の背景画像位置をもとに、背景画像のX座標を更新する
        backGround.CheckCameraPositionAndUpdate();
    }
}
