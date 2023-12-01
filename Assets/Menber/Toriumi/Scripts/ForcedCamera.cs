using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedCamera : MonoBehaviour
{
    // �X�N���[���X�s�[�h
    public float ScrollSpeed = 1f;
    private bool _CmaraActive = true;
    [SerializeField]
    private GameObject _goaltile;
    private Vector2 _position;

    // Update is called once per frame
    void Update()
    {
        _position = new Vector2(_goaltile.transform.position.x, _goaltile.transform.position.y);
        // �������Ȃ̂�-��t����
        if (_CmaraActive == true)
        {
            this.transform.position += new Vector3(-ScrollSpeed * Time.deltaTime, 0, 0);
        }
        if (this.transform.position.x <= _position.x + 0.2f)
        {
            ScrollSpeed = 0f;
        }

    }
}
