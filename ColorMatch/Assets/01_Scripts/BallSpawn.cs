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
        }
    }

    public void SpawnBall()
    {
        int r =  Random.Range(0, balls.Length); // 공의 랜덤값
        int r1 =  Random.Range(0, balls.Length); // 색과 태그의 랜덤값

        GameObject ball = balls[r]; // 공 게임 오브젝트 공 중에 랜덤
        ball.tag = tagName[r1]; // 공의 태그를 랜덤으로 받아옴
        SpriteRenderer sp = ball.GetComponent<SpriteRenderer>();
        sp.color = ballColor[r1]; // 공의 색을 태그와 값은 랜덤값으로 설정

        Instantiate(ball, trans[r].position , Quaternion.identity); 
    }
}
