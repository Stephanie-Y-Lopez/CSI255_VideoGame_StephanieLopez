using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpDistance = 10;
    public bool isGrounded = false;
    public bool canJump = true;
    public int maxJumps = 2;

    public int numOfJumps = 0;

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
        float x = Input.GetAxis("Horizontal");
        float movement = x * speed * Time.deltaTime;
        transform.Translate(new Vector2(movement,0));

        if(Input.GetButtonDown("Jump") && canJump ) {

            
            if(numOfJumps < maxJumps) {
                rb.AddForce(Vector2.up * jumpDistance, ForceMode2D.Impulse);
            }

            numOfJumps++;
        }

        // if(Input.GetButtonDown("Jump") && numOfJumps < maxJumps) {
        //     numOfJumps++;
        //     rb.AddForce(Vector2.up * jumpDistance, ForceMode2D.Impulse);
        // }

    }

    // Colliders
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "resetJump") {
            isGrounded = true;
            numOfJumps = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        isGrounded = false;
    }

}
