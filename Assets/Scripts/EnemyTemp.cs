using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyTemp : MonoBehaviour
{

    // Hello again stephanie
    public float speed;
    public float bounce = 2;
    // Start is called before the first frame update
    void Start()
    {
        // 2nd last frame|   last frame |
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {

        GameObject playerObject;

        if(other.gameObject.tag == "Player") {
            playerObject = other.gameObject;
            Destroy(gameObject);     

            if(playerObject.tag == "Player") {
                playerObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
        }

          
            
    }


}
