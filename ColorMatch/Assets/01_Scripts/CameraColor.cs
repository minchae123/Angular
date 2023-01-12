using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    public Camera cam;

    public Color[] color;

    private void Update()
    {
        cam.backgroundColor = color[GameManager.instance.level];
    }
}
