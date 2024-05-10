using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stephanie Lopez
public class Player : MonoBehaviour
{
    //Fields
    public Animator animator; // Refrences Animator in unity
    public int PlayerSpeed = 10;
    public bool PlayerFacingRight = true;
    public int JumpDistance = 5;
    private float movementX;
    public bool isGrounded = false; // Tracks whether the player is grounded

    //RigidBody rb;

    void Start()
    {
        Debug.Log("This works");
        
    }

    // Update is called once per frame
    void Update()
    {
        // Allow the player to jump only when grounded and canJump is true



        //if (isGrounded && Input.GetButtonDown("Jump"))
        //{
        //    Jump();
        //}

        

       
        PlayerMovement();
    }

    public void OnCollisonEnter2D(Collision2D other)
    {
        Debug.Log(LayerMask.LayerToName(other.gameObject.layer));
        if(other.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void PlayerMovement()
    {
        //Movement controls
        movementX = Input.GetAxis("Horizontal");

        //Animations

        //Player Facing Direction
        if (movementX > 0.0f && !PlayerFacingRight)
        {
            FlipPlayer();
        }
        else if (movementX < 0.0f && PlayerFacingRight)
        {
            FlipPlayer();
        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementX * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpDistance));
    }

    void FlipPlayer()
    {
        PlayerFacingRight = !PlayerFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}