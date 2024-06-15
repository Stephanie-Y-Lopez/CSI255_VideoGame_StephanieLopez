using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez

public class DeathController : MonoBehaviour
{
    //private bool isDead;<IsDeadScreen

    // Start is called before the first frame update
    //public SceneController gameManger; <IsDeadScreen
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            //isDead = true;<IsDeadScreen
            //gameManger.gameOver();<IsDeadScreen
            //Debug.Log($"{this.name} collided with player");
            // Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX("diesound");
            SceneManager.LoadScene("GameOver");
        }
    }
}
