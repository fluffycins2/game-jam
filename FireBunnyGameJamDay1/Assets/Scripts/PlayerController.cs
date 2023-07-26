using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool facingRight = true;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input (left/right)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the character
        Vector2 moveVelocity = rb.velocity;
        moveVelocity.x = horizontalInput * moveSpeed;
        rb.velocity = moveVelocity;

        // Flip the character sprite when moving left
        if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }

        // Update the animator parameters for idle/moving animations
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}