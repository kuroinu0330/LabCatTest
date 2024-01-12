using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resulimage : MonoBehaviour
{
    [SerializeField]
    MobCatMg MobCatMg;
    // Start is called before the first frame update
    // Update is called once per frame
    [SerializeField]
    private GameObject _Cat0;
    [SerializeField]
    private GameObject _Cat01;
    [SerializeField]
    private GameObject _Cat02;
    [SerializeField]
    private GameObject _Cat03;
    [SerializeField]
    private GameObject _Cat04;
    [SerializeField]
    private GameObject _Cat05;
    [SerializeField]
    private GameObject _Cat06;
    [SerializeField]
    private GameObject _Cat07;
    void Start()
    {
        switch (MobCatMg.instance.CatCount)
        {
            case 0:
                if (MobCatMg.instance.CatCount == 0)
                {
                    _Cat0.SetActive(true);
                }
                else
                {
                    _Cat0.SetActive(false);
                }
                break;
            case 1:
                if (MobCatMg.instance.CatCount == 1)
                {
                    _Cat01.SetActive(true);
                }
                else
                {
                    _Cat01.SetActive(false);
                }
                break;
            case 2:
                if (MobCatMg.instance.CatCount == 2)
                {
                    _Cat02.SetActive(true);
                }
                else
                {
                    _Cat02.SetActive(false);
                }
                break;
            case 3:
                if (MobCatMg.instance.CatCount == 3)
                {
                    _Cat03.SetActive(true);
                }
                else
                {
                    _Cat03.SetActive(false);
                }
                break;
            case 4:
                if (MobCatMg.instance.CatCount == 4)
                {
                    _Cat04.SetActive(true);
                }
                else
                {
                    _Cat04.SetActive(false);
                }
                break;
            case 5:
                if (MobCatMg.instance.CatCount == 5)
                {
                    _Cat05.SetActive(true);
                }
                else
                {
                    _Cat05.SetActive(false);
                }
                break;
            case 6:
                if (MobCatMg.instance.CatCount == 6)
                {
                    _Cat06.SetActive(true);
                }
                else
                {
                    _Cat06.SetActive(false);
                }
                break;
            case 7:
                if (MobCatMg.instance.CatCount == 7)
                {
                    _Cat07.SetActive(true);
                }
                else
                {
                    _Cat07.SetActive(false);
                }
                break;
        }
    }
}
