using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;

    private Rigidbody2D rigidBody;
    private float moveDirection;
    private bool isJumping = false;
    private bool facingRight = true;
    private bool isGrounded;
    
   
    
    //Awake is called before Start, after all objects are initialized. Called in random order.
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //will look for a component on this GameObject of type RigidBody2D.
    }
    

    // Update is called once per frame
    void Update()
    {
        // Get Inputs
        ProcessInputs();

        //Animate
        Animate();

    }

    // Better for handling physics, can be called mulitple ties per update frame.
    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

        //Move
        Move();
    }


    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); //Scale of -1 -> 1
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }
    
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);
        if (isJumping)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }


}
