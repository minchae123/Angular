using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    public Transform tr;

    public float turnAngle = 90;    // Angle to turn in degrees;
    public float angle;

    public void Left()
    {
        angle += -turnAngle;
        transform.DORotate(new Vector3(0, 0, angle),0.5f);
    }

    public void Right()
    {
        angle += turnAngle;
        transform.DORotate(new Vector3(0, 0, angle), 0.5f);
    }
}
