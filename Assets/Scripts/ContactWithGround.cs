using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Stephanie Lopez

public class ContactWithGround : MonoBehaviour
{
    bool isGrounded = false;
    Rigidbody2D rb;
    public int jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 800;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (isGrounded)
        //    {
        //        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Gets the layer of the item you collide with as an int
        int layerNumber = other.gameObject.layer;
        // Converts that number to the layer name
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        // This is the name we want to respond to
        string groundLayerName = "Ground";

        // Checks if the layer is a ground. Set to true if it's not
        if (layerName == groundLayerName)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // When OZ LEAVES the collsion ( here jumping off the ground), turn is ground off.
        if (LayerMask.LayerToName(other.gameObject.layer) == "Ground")
        {
            isGrounded = false;
        }
    }
}
