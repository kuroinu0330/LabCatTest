using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMg : MonoBehaviour
{
    private void Update()
    {
        Click();
    }
    public void Click()
    {
        StartCoroutine(cooltime());
    }
    public IEnumerator cooltime()
    {
        yield break;
    }
}
