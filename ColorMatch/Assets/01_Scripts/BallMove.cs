using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public Vector3 moveDir;

    public float speed;

    private void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == this.tag)
        {
            Debug.Log("O");
        }
        else
        {
            Debug.Log("X");
        }
    }
}
