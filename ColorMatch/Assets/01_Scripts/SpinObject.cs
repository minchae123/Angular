using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinObject : MonoBehaviour
{
    public float speed;
    private void Awake()
    {
        StartCoroutine(Spin());
    }

    private void Update()
    {
    }

    IEnumerator Spin()
    {
        transform.DORotate(new Vector3(0, 0, 360), speed, RotateMode.FastBeyond360)
             .SetEase(Ease.Linear)
             .SetLoops(-1);
        yield return null;
        // yield return new WaitForSeconds(speed);
    }
}
