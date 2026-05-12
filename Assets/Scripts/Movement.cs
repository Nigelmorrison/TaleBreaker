using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float jumpVelocity = 5;
    Rigidbody rb;
    Animator anim;
    //private Animator _animator;
    SpriteRenderer sprite;
    public ParticleSystem dustTrail;
    bool onGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Flip(bool flip)
    {
        sprite.flipX = flip;
    }

    public void TickMovement(Vector3 direction)
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = direction.x * speed;
        velocity.z = direction.z * speed;
        rb.linearVelocity = velocity;
        if (direction.magnitude > 0.01)
        {
             anim.SetBool("isRunning", true);
            CreateDustTrail();
        }
        else
        {
            anim.SetBool("isRunning", false);
            
        }
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

    private void CreateDustTrail()
    {
        dustTrail.Play();
    }

    public void OnAttacked()
    {
        anim.SetTrigger("Damage");
    }

    public void OnIdle()
    {
        anim.SetTrigger("Idle");
    }
}
