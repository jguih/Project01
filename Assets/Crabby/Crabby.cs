using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby : MonoBehaviour
{
    private bool isFacingLeft = true;

    public Rigidbody2D Rb;
    public SpriteRenderer SpriteRenderer;
    public CustomCollider LeftCollider;
    public CustomCollider RightCollider;
    public CustomCollider HeadCollider;
    public float speed = 2f;

    private void Start()
    {
        LeftCollider.AddListener((collision) =>
        {
            if (collision.tag == "Player")
            {
                Destroy(collision.gameObject);
            }
            if (isFacingLeft)
            {
                Flip();
            }
        });

        RightCollider.AddListener((collision) =>
        {
            if (collision.tag == "Player")
            {
                Destroy(collision.gameObject);
            }
            if (!isFacingLeft)
            {
                Flip();
            }
        });

        HeadCollider.AddListener((_) =>
        {
            Destroy(gameObject);
        });
    }

    private void FixedUpdate()
    {
        if (isFacingLeft)
        {
            Rb.velocity = new Vector2(-speed, Rb.velocity.y);
        } else
        {
            Rb.velocity = new Vector2(speed, Rb.velocity.y);
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        SpriteRenderer.flipX = !SpriteRenderer.flipX;
    }
}
