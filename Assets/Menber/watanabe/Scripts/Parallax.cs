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
        // �w�i�摜��x���W
        startpos = transform.position.x;
        // �w�i�摜��x�������̕�
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

        // �����X�N���[���Ɏg�p����p�����[�^�[
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // �w�i�̎������ʂɎg�p����p�����[�^�[
        float dist = (cam.transform.position.x * parallaxEffect);

        // �������ʂ�^���鏈��
        // �w�i�摜��x���W��dist�̕��ړ�������
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + length)
        {
            _countMap++;
        }
        else if (temp < startpos - length)
        {
            _countMap++;
        }
        // �����X�N���[��
        // ��ʊO�ɂȂ�����w�i�摜���ړ�������
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
