using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX("diesound");
        }
    }
}
