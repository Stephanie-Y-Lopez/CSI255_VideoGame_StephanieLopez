using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Fields
    public Animator animator; //Refrences to Animator
    public float speed;
    private float movementX;
    //Jump stuff
    public float jumpDistance = 10;
    public bool isGrounded = false;
    public bool canJump = true;
    public int maxJumps = 2;
    public int numOfJumps = 0;
    // Jump stuff ^^
    public bool PlayerFacingRight = true;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        movementX = Input.GetAxis("Horizontal");
        float movement = movementX * speed * Time.deltaTime;

        if (!PlayerFacingRight)
        {
            movement *= -1; // ReverseS movement if facing left
        }
    
        transform.Translate(new Vector2(movement, 0));

        if(Input.GetButtonDown("Jump") && canJump ) 
        {
            if(numOfJumps < maxJumps) 
            {
                rb.AddForce(Vector2.up * jumpDistance, ForceMode2D.Impulse);
            }

            numOfJumps++;
        }

        PlayerFacing();
    }

    // Colliders
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "resetJump") 
        {
            isGrounded = true;
            numOfJumps = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        isGrounded = false;
    }

    void PlayerFacing()
    {
        //Player Facing Direction
        if (movementX > 0.0f && !PlayerFacingRight)
        {
            FlipPlayer();
        }
        else if (movementX < 0.0f && PlayerFacingRight)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        PlayerFacingRight = !PlayerFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}