using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject[] balls;

    public Transform[] trans;

    public string[] tagName;
    public Color[] ballColor;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnBall();
            Debug.Log("s");
        }
    }

    public void SpawnBall()
    {
        int r =  Random.Range(0, balls.Length);
        balls[r].tag = tagName[r];
        SpriteRenderer sp = balls[r].GetComponent<SpriteRenderer>();
        sp.color = ballColor[r];
        Instantiate(balls[r], trans[r].position , Quaternion.identity);
    }
}
