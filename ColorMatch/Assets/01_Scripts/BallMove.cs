using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public Vector3 moveDir;

    public float speed;
    public float Speed { get => speed; set => speed = value; }

    public float max;
    public float min;

    public float delay;

    public bool isCheck = false;
    public ParticleSystem destroyEffect;

    public AudioClip successAudio;
    public AudioClip failAudio;

    SpriteRenderer sp;
    AudioSource audioSource;
    CircleCollider2D circleCollider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        if(GameManager.instance.level == 0)
        {
        }
        if(GameManager.instance.level == 1)
        {
            min += 0.3f;
            max += 0.6f;
        }

        if (GameManager.instance.level == 2)
        {
            min += 0.4f;
            max += 0.8f;
        }

        if(GameManager.instance.level == 3)
        {
            min += 0.6f;
            max += 1.0f;
        }

        speed = Random.Range(min, max);
    }

    private void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isCheck == false)
        {
            isCheck = true;
            circleCollider.enabled = false;
            StartCoroutine(DestroyBall());
            
            if (collision.gameObject.tag == tag)
            {
                BallSpawn.instance.isCorrect = true;
                Debug.Log("O");
                GameManager.instance.score += 100;
                audioSource.PlayOneShot(successAudio);
            }
            else
            {
                Debug.Log("X");
                GameManager.instance.heart[GameManager.instance.health--].SetTrigger("Remove");
                audioSource.PlayOneShot(failAudio);
            }
        }
    }

    IEnumerator DestroyBall()
    {
        speed = 0;
        destroyEffect.Play();
        sp.enabled = false;
        yield return new WaitForSeconds(delay);

        BallSpawn g = FindObjectOfType<BallSpawn>();
        if (g != null)
        {
            BallSpawn.instance.ballCount--;
            BallSpawn.instance.SpawnBall();
        }
        Destroy(gameObject);
    }
}
