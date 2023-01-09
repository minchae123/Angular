using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public Vector3 moveDir;

    public float speed;
    public float Speed { get => speed; set => speed = value; }

    public float delay;

    public ParticleSystem destroyEffect;

    SpriteRenderer sp;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
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
            GameManager.instance.score -= 100;
        }
    }

    IEnumerator DestroyBall()
    {
        destroyEffect.Play();
        sp.enabled = false;
        yield return new WaitForSeconds(delay);
        BallSpawn.instance.SpawnBall();
        Destroy(gameObject);
    }
}
