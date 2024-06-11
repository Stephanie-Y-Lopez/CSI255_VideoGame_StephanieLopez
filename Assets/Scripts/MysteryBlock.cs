using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Stephanie Lopez

public class MysteryBlock : MonoBehaviour
{
    //Fields
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4f;
    private Vector2 originalPosition;
    private bool canBounce = true;
    public Sprite emptyBlockSprite;

    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mysteryBlockBounce()
    {
        if(canBounce)
        {
            canBounce = false;
            //Coroutine will called Bounce method
            StartCoroutine(Bounce());
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player") {
            mysteryBlockBounce();

            GameObject newCoin = Instantiate(coin);
            
            newCoin.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            newCoin.GetComponent<Rigidbody2D>().AddForce(Vector2.up + new Vector2(0,3), ForceMode2D.Impulse);
        }

        GameObject playerObject;
        if(other.gameObject.tag == "Player") 
        {
            playerObject = other.gameObject;
            Destroy(gameObject);     
        }
    }


    IEnumerator Bounce()
    {
        while (true)
        {
            // Will transform the position of the x and y of mysteryBlock. 
            transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            //if the block is greater than or equal to this statement, it will finish the loop. 
            if (transform.localPosition.y >= originalPosition.y + bounceHeight)
            break;
            //This loop is for y the next loop is for x.
            yield return null;
        }

        while (true)
        {
            transform.localPosition = new Vector2 (transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y >= originalPosition.y + bounceHeight)
            {
                //This makes sure the block goes back exactly where it was before. 
                transform.localPosition = originalPosition;
                break;
            }
            yield return null;
        }
    }

    void ChangeSprite()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer> ().sprite = emptyBlockSprite;
    }
}
