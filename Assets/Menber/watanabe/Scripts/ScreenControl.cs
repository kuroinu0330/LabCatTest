using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    //public MobCatMg _mobCatMg;
    //public MobCat _mobCat;
    [SerializeField] 
    private float _minX,
                  _maxX,
                  _minY,
                  _maxY;


    // Update is called once per frame

    public void ScreenCat()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;
    }
}
