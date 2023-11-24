using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManagerTest;

public class BGBGM : MonoBehaviour
{
    [SerializeField, Header("ƒ`ƒƒƒ“ƒlƒ‹")]
    private int _Channel;

    // Update is called once per frame
    void Start()
    {
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
    }
}
