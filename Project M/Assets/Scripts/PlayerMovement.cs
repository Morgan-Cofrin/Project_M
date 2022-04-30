using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    private float moveDirection;

    private Rigidbody2D rigidBody;
    private bool facingRight = true;

    
    //Awake is called before Start, after all objects are initialized. Called in random order.
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //will look for a component on this GameObject of type RigidBody2D.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Inputs
        moveDirection = Input.GetAxis("Horizontal"); //Scale of -1 -> 1

        //Animate
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }

        //Move
        rigidBody.velocity = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);

    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }


}
