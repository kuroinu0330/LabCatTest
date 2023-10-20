using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedCamera : MonoBehaviour
{
    // スクロールスピード
    public float ScrollSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // 左強制なので-を付ける
        this.transform.position += new Vector3(-ScrollSpeed * Time.deltaTime, 0, 0);
    }
}
