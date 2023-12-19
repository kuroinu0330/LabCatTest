using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    //public MobCatMg _mobCatMg;
    //public MobCat _mobCat;

    [SerializeField]
    private GameObject Testobj;
    private Vector3 hogeobj;
    private void Start()
    {
        Debug.Log("ScreenWidth:" + Screen.width + "," + "ScreenHeight:" + Screen.height);
    }
    // Update is called once per frame
    void Update()
    {
        /*for (int num = 0; num < 8; num++)
        {
            if (_mobCatMg.MobCats[num].transform.position.x > 1.0f * Screen.width)
            {
                Debug.Log("‚Å‚½‚º");
                _mobCat.move = MobCat.MobCatMove.Free;
            }
        }*/
        hogeobj = Testobj.transform.position;
        hogeobj = Camera.main.WorldToScreenPoint(transform.position);
        if (Testobj.transform.position.x > 1.0f * Screen.width)
        {
            Debug.Log("‚Å‚½‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ");
        }
    }
}
