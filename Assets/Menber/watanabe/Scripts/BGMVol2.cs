using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManagerTest; 

public class BGMVol2 : MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
    private int _Channel;
    // Start is called before the first frame update
    void Start()
    {
        SoundManagerTest.instance.PlayAudioSorce(AudioOfType.BGM, _Channel);
    }

    // Update is called once per frame
}