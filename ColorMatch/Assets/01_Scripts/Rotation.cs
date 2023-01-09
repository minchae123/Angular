using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    public Transform tr;

    public float turnAngle = 90;
    public float angle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
    }

    public void Left()
    {
        angle += turnAngle;
        if(angle == 360)
        {
            angle = 0;
        }
        transform.DORotate(new Vector3(0, 0, angle), 0.1f);
        
    }

    public void Right()
    {
        angle -= turnAngle;
        if (angle == -360)
        {
            angle = 0;
        }
        transform.DORotate(new Vector3(0, 0, angle), 0.1f);
    }
}
