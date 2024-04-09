using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float Horizontal;
    private float Speed = 6f;
    private float JumpingPower = 14f;

    public Rigidbody2D Rb;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpingPower);
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = new Vector2(Horizontal * Speed, Rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
}
