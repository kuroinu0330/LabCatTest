using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundTest : MonoBehaviour
{
    Object.Stage.BackGround backGround;

    private void Start()
    {
        backGround = new Object.Stage.BackGround(
            GetComponent<SpriteRenderer>(), // �w�i�摜
            Camera.main, // ��ƂȂ�J����
            1 // [�Ԕ�][�Ԕ�][�Ԕ�][�Ԕ�] ��4��J��Ԃ��Ă���̂�4�B�摜�̑傫���Ƒ��k���Ȃ��璲������B
        );
    }

    private void LateUpdate()
    {
        // �J�����ʒu�ƌ��݂̔w�i�摜�ʒu�����ƂɁA�w�i�摜��X���W���X�V����
        backGround.CheckCameraPositionAndUpdate();
    }
}
