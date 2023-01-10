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

    public ParticleSystem destroyEffect;

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
        if(GameManager.instance.score >= 1500)
        {
            min += 0.3f;
            max += 0.6f;
        }

        if(GameManager.instance.score >= 2300)
        {
            min += 0.5f;
            max += 0.8f;
        }

        if(GameManager.instance.score >= 3000)
        {
            min += 0.3f;
            max += 0.2f;
        }
        speed = Random.Range(min, max);
        
    }

    private void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tag)
        {
            Debug.Log("O");
            StartCoroutine(DestroyBall());
            GameManager.instance.score += 100;
        }
        else
        {
            Debug.Log("X");
            StartCoroutine(DestroyBall());
            GameManager.instance.heart[GameManager.instance.health--].SetTrigger("Remove");
            GameManager.instance.score -= 100;
        }
    }

    IEnumerator DestroyBall()
    {
        circleCollider.enabled = false;
        speed = 0;
        destroyEffect.Play();
        sp.enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        BallSpawn.instance.SpawnBall();
    }
}
