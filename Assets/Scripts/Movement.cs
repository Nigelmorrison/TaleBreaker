using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float jumpVelocity = 5;
    Rigidbody rb;
    Animator anim;
    bool onGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void TickMovement(Vector3 direction)
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = direction.x * speed;
        velocity.z = direction.z * speed;
        rb.linearVelocity = velocity;
    }

    internal void Jump()
    {
        if (onGround)
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.y = jumpVelocity;
            rb.linearVelocity = velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
