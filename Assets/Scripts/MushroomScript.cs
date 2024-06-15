using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Player") {
            Transform player = other.gameObject.transform;
            player.localScale = player.localScale * 2;
            Destroy(gameObject);
        }


    }


}
