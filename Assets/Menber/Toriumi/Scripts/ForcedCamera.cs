using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedCamera : MonoBehaviour
{
    // �X�N���[���X�s�[�h
    public float ScrollSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // �������Ȃ̂�-��t����
        this.transform.position += new Vector3(-ScrollSpeed * Time.deltaTime, 0, 0);
    }
}
