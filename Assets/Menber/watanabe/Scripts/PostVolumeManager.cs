using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostVolumeManager : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume _PPV;
    // Start is called before the first frame update
    void Start()
    {
        _PPV = GetComponent<PostProcessVolume>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("center"))
        {
            _PPV.weight = 1.0f;
        }

    }
}
