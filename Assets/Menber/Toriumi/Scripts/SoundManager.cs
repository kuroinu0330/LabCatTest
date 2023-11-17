using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMAudio;
    [SerializeField] AudioSource SEAudio;

    [SerializeField] List<BGMSoundData> BGMDatas;
    [SerializeField] List<SESoundData> SEDatas;

    public float MasterVolume = 1;
    public float BGMMasterVolume = 1;
    public float SEMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        // 2������������B��������Ȃ���Ύc���B

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = BGMDatas.Find(data => data.bgm == bgm);
        BGMAudio.clip = data.audioClip;
        BGMAudio.volume = data.volume * BGMMasterVolume * MasterVolume;
        BGMAudio.Play();
    }

    public void StopBGM(BGMSoundData.BGM bgm)
    {
        BGMAudio.Stop();
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = SEDatas.Find(data => data.se == se);
        SEAudio.clip = data.audioClip;
        SEAudio.volume = data.volume * SEMasterVolume * MasterVolume;
        SEAudio.Play();
    }

    public void StopSE(SESoundData.SE se)
    {
        SEAudio.Stop();
    }

}

[System.Serializable]
public class BGMSoundData
{
    // �����Ɏg��BGM�̖��O������
    public enum BGM
    {
        //��
        OP,
        ED,
        
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    // �����Ɏg��SE�̖��O������
    public enum SE
    {
        // ��
        Cat,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

// �g�������Ƃ���ɂ����˂�����
//SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);

// ����Ŏ~�܂�
//SoundManager.Instance.StopBGM(BGMSoundData.BGM.Title);

