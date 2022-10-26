  using System;
  using System.Collections;
using System.Collections.Generic;
  using Unity.VisualScripting;
  using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;
    public float jumpForce;
    public SpriteRenderer[] sprite;

    private bool grounded;
    void Start()
    {
        sprite = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        print(x);

        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        animator.SetFloat("IsRunning",Mathf.Abs(x));

        if (x > 0)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].flipX = true;
            }
        }
        
        if(x < 0)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].flipX = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping",true);
        }
        else
        {
            animator.SetBool("IsJumping",false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}