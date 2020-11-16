using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitrusFalling : MonoBehaviour
{
    public float speed;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            Destroy(gameObject);
    }
}
