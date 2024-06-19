using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Stephanie Lopez

public class MushroomScript : MonoBehaviour
{
    public float speedBoostDuration = 2f; //Speed boost will last 2 seconds!
    public float speedIncrease = 4f;
    private bool isCollected = false;  //Mushroom will only be collected once.



    public GameObject timerManager;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {

    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {     
        if (other.gameObject.tag == "Player" && !isCollected)
        {
            Debug.Log("Player collected the mushroom"); // Debug log to confirm player collection
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.SpeedUp(speedIncrease, speedBoostDuration);
            Destroy(gameObject);

            // Mushroom Pool Code ( Bullet Pool )
            // gameObject.transform.SetParent(timerManager.transform);
            // gameObject.transform.position = timerManager.transform.position;
            // gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

            // isCollected = true;
            // Transform player = other.gameObject.transform;
            // StartCoroutine(ApplySpeedBoost(player));
            // // Will destroy the mushroom!
            // Destroy(gameObject); 
        }
    }

    private IEnumerator ApplySpeedBoost(Transform player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        float originalSpeed = playerController.speed;
        playerController.speed += 4; //Will increase speed by 4 paces for mushroom duration. 

        yield return new WaitForSeconds(speedBoostDuration);

        playerController.speed = originalSpeed; //Will return to original speed. 
    }


}
