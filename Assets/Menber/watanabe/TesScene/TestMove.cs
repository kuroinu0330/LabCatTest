using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField, Tooltip("�^�[�Q�b�g�I�u�W�F�N�g")]
    private List<GameObject> TargetObject = new List<GameObject>();

    [SerializeField, Tooltip("��]��")]
    private Vector3 RotateAxis = Vector3.up;

    [SerializeField, Tooltip("���x�W��")]
    private float SpeedFactor = 0.1f;
    [SerializeField]
    private bool isActive = false;
    void FixedUpdate()
    {
        float z = transform.localEulerAngles.z;
        if (isActive == true)
        {
            for (int i = 0; i < 2; i++)
            {
                if (TargetObject[i] == null) return;
                this.transform.RotateAround(TargetObject[i].transform.position,RotateAxis,
                    360.0f / (10.0f / SpeedFactor) * Time.deltaTime);
            }
        }
        if (z > 180)
        {
            isActive = false;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MobCat"))
        {
            isActive = true;
        }
    }
}
