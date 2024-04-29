using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float Speed = 6f;
    private float JumpingPower = 14f;
    private bool isFacingRight = true;

    public Rigidbody2D Rb;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public SpriteRenderer SpriteRenderer;
    public Animator Animator;
    public CustomCollider EntityCollider;

    private void Start()
    {
        EntityCollider.AddListener((collision) =>
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpingPower);
        }

        Flip();
        Animate();
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(horizontal * Speed, Rb.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.2f, GroundLayer);
        
        if (hit.collider == null)
        {
            return false;
        } 
        else
        {
            return true;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
        }
    }

    private void Animate()
    {
        if (horizontal != 0)
        {
            Animator.SetBool("isRunning", true);
        }
        else
        {
            Animator.SetBool("isRunning", false);
        }
    }
}
