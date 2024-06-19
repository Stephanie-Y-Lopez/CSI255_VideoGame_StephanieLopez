using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Stephanie Lopez

public class PlayerController : MonoBehaviour
{
    //Fields
    public Animator animator; //Refrences to Animator
    public float speed;
    public float movementX;
    //Jump stuff
    public float jumpDistance = 10;
    public bool isGrounded = false;
    public bool canJump = true;
    public int maxJumps = 2;
    public int numOfJumps = 0;
    public float deadZone = .1f;
    // Jump stuff ^^
    public bool PlayerFacingRight = true;
    Rigidbody2D rb;
    RaycastHit2D hitRay;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement
        movementX = Input.GetAxis("Horizontal");
        float movement = movementX * speed * Time.deltaTime;
        //bool isRunning = !(movementX > -(deadZone * -1) && movementX < deadZone);
        //Code right below makes it so that the still animation transitions over to the walkings animation!
        bool isRunning  = Input.GetButton("Horizontal");
        animator.SetBool("isRunning", isRunning);

        if (!PlayerFacingRight)
        {
            movement *= -1; //Reverses movement if facing left
        }
    
        transform.Translate(new Vector2(movement, 0));

        if(Input.GetButtonDown("Jump") && canJump ) 
        {
            animator.SetBool("Jump", true);
            canJump = true;

            if(numOfJumps < maxJumps) 
            {
                rb.AddForce(Vector2.up * jumpDistance, ForceMode2D.Impulse);
            }

            numOfJumps++;
            AudioManager.Instance.PlaySFX("Jump");
        }

        PlayerFacing();

        //For jumping animation
        animator.SetFloat("YVelocity", rb.velocity.y);
    }

    // Colliders
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "resetJump") 
        {
            isGrounded = true;
            numOfJumps = 0;

            //If Oz is grounded, jump will be false. 
            animator.SetBool("Jump", !isGrounded);
        }
        
        // if(hitRay.collider.tag == "MysteryBlock")
        // {
        //     hitRay.collider.GetComponent<MysteryBlock>().mysteryBlockBounce();
        // }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        isGrounded = false;
    }

    public void SpeedUp(float speedIncrease, float time) {
        // StartCoroutine(SpeedUpCode(speedIncrease, time ));
        StartCoroutine(ApplySpeedBoost(transform));


        // speed += 4
    }

    public IEnumerator SpeedUpCode(float speedIncrease, float time) {

        Debug.Log("Speed up starting");
        float originalSpeed = speed;
        speed += speedIncrease; //Will increase speed by 4 paces for mushroom duration. 

        yield return new WaitForSeconds(time);

        Debug.Log("Speed is ending");
        speed = originalSpeed; //Will return to original speed. 

    }

        private IEnumerator ApplySpeedBoost(Transform player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        float originalSpeed = playerController.speed;
        playerController.speed += 4; //Will increase speed by 4 paces for mushroom duration. 

        yield return new WaitForSeconds(2);

        playerController.speed = originalSpeed; //Will return to original speed. 
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

    //Still animation threshold is 0, Walking animationb threshold is 10, just like walking speed. 
    // void AnimatorIfWorking()
    // {
    //     animator.SetFloat("Oz_Walking", Mathf.Abs(rb.velocity.x));
    // }
}