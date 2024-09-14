using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    // private Vector2 moveInput;
    public float moveSpeed = 5f;
    private Vector2 direction, postureDirection;
    
    //reference to input actions
    public CharacterAction characterAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        
        if (direction != Vector2.zero)
        {
            // if (direction.x != 0)
            // {
            //     direction.x /= Math.Abs(direction.x);
            // }
            // if (direction.y != 0)
            // {
            //     direction.y /= Math.Abs(direction.y);
            // }
            rb.velocity = direction * moveSpeed;
            animator.SetBool("IsMoving", true);
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            postureDirection = direction;
        } else
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("IsMoving", false);
            animator.SetFloat("PostureHorizontal", postureDirection.x);
            animator.SetFloat("PostureVertical", postureDirection.y);
        }


    }

}