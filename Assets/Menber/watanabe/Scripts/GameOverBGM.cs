using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManagerTest;

public class GameOverBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, 1);
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, 2);
    }
}
