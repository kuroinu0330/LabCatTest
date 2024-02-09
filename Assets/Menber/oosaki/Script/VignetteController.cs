using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public float effectDuration = 5f; // �G�t�F�N�g�̎������ԁi�b�j

    private Vignette vignette;
    private float initialIntensity;
    private float elapsedTime = 0f; // �o�ߎ���

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        initialIntensity = vignette.intensity.value; // �ŏ��̌����̋��x��ۑ�
    }

    void Update()
    {
        // �o�ߎ��Ԃ��X�V
        elapsedTime += Time.deltaTime;

        // �w�肵�����Ԃ��o�߂����猸���̋��x�����ɖ߂�
        if (elapsedTime >= effectDuration)
        {
            vignette.intensity.value = 0f; // �����̋��x��0�ɂ���i�G�t�F�N�g�������j
            enabled = false; // ���̃X�N���v�g�𖳌��ɂ���i�s�v�ɂȂ�����X�V�������~����j
        }
        else
        {
            // �c�莞�Ԃɑ΂��銄�����v�Z���A����Ɋ�Â��Č����̋��x������������
            float remainingTimeRatio = 1f - (elapsedTime / effectDuration);
            vignette.intensity.value = initialIntensity * remainingTimeRatio;
        }
    }
}


