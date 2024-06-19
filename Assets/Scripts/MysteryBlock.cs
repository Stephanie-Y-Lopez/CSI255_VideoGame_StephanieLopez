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

    public GameObject mushroomPrefab;
    //private bool SpawnedMushroom = false; 

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

  
     private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && canBounce)
        {
            canBounce = false;
            StartCoroutine(Bounce());
        }
    }


    private IEnumerator Bounce()
    {
        Vector2 targetPosition = new Vector2(originalPosition.x, originalPosition.y + bounceHeight);

        // Will move block to do upwards animation
        while (transform.localPosition.y < targetPosition.y)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure it exactly reaches the target position
        transform.localPosition = targetPosition;

        // Will return position
        while (transform.localPosition.y > originalPosition.y)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure it exactly reaches the original position
        transform.localPosition = originalPosition;

        // Will spawn mushroom and change sprite
        SpawnMushroom();
        ChangeSprite();

        // Will Destroy the block after a tiny delay,
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }


    void SpawnMushroom()
    {
        GameObject newMushroom = Instantiate(mushroomPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        // Will destroy the mushroom after a certain time if not collected!
        Destroy(newMushroom, 10f);
    }


    void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
    }
}
