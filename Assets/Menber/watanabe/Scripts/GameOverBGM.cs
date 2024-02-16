using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManagerTest;

public class GameOverBGM : MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
    private int _Channel;
    [SerializeField, Header("�`�����l��2")]
    private int _Channel2;
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, _Channel2);
    }
}
