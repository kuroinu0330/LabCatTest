using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume postProcessVolume;
    [SerializeField]
    private float effectDuration = 5f; // �G�t�F�N�g�̎������ԁi�b�j

    //private Vignette vignette;
    private float initialIntensity;
    private float elapsedTime = 0f; // �o�ߎ���

    [SerializeField]
    private bool _PostWeightStart = false;
    [SerializeField]
    private float _PostWeightStartTime = 0.0f;
    private float __PostWeightStartTimeLimit = 1.0f;
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        _PostWeightStart = false;
        //postProcessVolume.profile.TryGetSettings(out vignette);
        //initialIntensity = vignette.intensity.value; // �ŏ��̌����̋��x��ۑ�
    }

    void Update()
    {
        PostWeight();
        /*
        // �o�ߎ��Ԃ��X�V
        elapsedTime += Time.deltaTime;

        // �w�肵�����Ԃ��o�߂����猸���̋��x�����ɖ߂�
        if (elapsedTime >= effectDuration)
        {
            postProcessVolume.weight = 1f; // �����̋��x��0�ɂ���i�G�t�F�N�g�������j
            enabled = false; // ���̃X�N���v�g�𖳌��ɂ���i�s�v�ɂȂ�����X�V�������~����j
        }
        else
        {
            // �c�莞�Ԃɑ΂��銄�����v�Z���A����Ɋ�Â��Č����̋��x������������
            float remainingTimeRatio = 0f + (elapsedTime / effectDuration);
            postProcessVolume.weight = initialIntensity * remainingTimeRatio;
        }
        */
    }
    private void PostWeight()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= effectDuration)
        {
            _PostWeightStart = true;
        }
        if (_PostWeightStart == true)
        {
            _PostWeightStartTime += Time.deltaTime * 0.005f;
            postProcessVolume.weight += _PostWeightStartTime;
        }
        
    }
}


