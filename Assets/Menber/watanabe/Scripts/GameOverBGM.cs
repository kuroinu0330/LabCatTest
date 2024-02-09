using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManagerTest;

public class GameOverBGM : MonoBehaviour
{
    [SerializeField, Header("ƒ`ƒƒƒ“ƒlƒ‹")]
    private int _Channel;
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
    }
}
