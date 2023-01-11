using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBall : MonoBehaviour
{
    public Sprite[] emoji;

    public Sprite heart;

    SpriteRenderer sprite;

    public bool isHeart = false;

    bool isCheck = false;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = emoji[Random.Range(0, emoji.Length)];
    }

    private void Start()
    {
        if (Random.Range(0, 10) < 5)
        {
            isHeart = true;
            sprite.sprite = heart;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isCheck == false)
        {
            isCheck = true;
            sprite.enabled = false;
            if (isHeart == true && BallSpawn.instance.isCorrect == true && GameManager.instance.health < 2)
            {
                Debug.Log("heal");
                GameManager.instance.health++;
                int health = GameManager.instance.health;
                Debug.Log(health);
                GameManager.instance.heart[health].SetTrigger("Recover");
            }
        }

    }
}
