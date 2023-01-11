using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public float spawnDelay = 2f;

    public static BallSpawn instance;
    public GameObject[] balls;

    public int ballCount = 0;
    public int maxBallCount = 1;

    public Transform[] trans;

    public string[] tagName;
    public Color[] ballColor;

    private AudioSource audioSource;
    public AudioClip spawnClip;

    private AudioSource audios;
    public AudioClip jumpSound;

    public bool isCorrect = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();

        this.audios = this.gameObject.AddComponent<AudioSource>();
        this.audios.clip = this.jumpSound;
        this.audios.loop = false;
    }

    private void Start()
    {
        SpawnBall();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnBall();
        }

    }

    public void SpawnBall()
    {
        isCorrect = false;
        if (ballCount < maxBallCount)
        {
            StartCoroutine(Spawn());
        }
        else
        {
            return;
        }
    }

    IEnumerator Spawn()
    {
        int r = Random.Range(0, balls.Length); // 공의 랜덤값
        int r1 = Random.Range(0, balls.Length); // 색과 태그의 랜덤값
 
        GameObject ball = balls[r]; // 공 게임 오브젝트 공 중에 랜덤
        ball.tag = tagName[r1]; // 공의 태그를 랜덤으로 받아옴
        SpriteRenderer sp = ball.GetComponent<SpriteRenderer>();
        sp.color = ballColor[r1]; // 공의 색을 태그와 값은 랜덤값으로 설정
 
        audioSource.PlayOneShot(spawnClip);
        ballCount++;
        Instantiate(ball, trans[r].position, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
    }
}
