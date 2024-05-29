using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Stephanie Lopez

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool nextLevel;
    [SerializeField] string levelName;

    [SerializeField] int nextLevelIndex;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log("This works");
    //     // SceneController.instance.NextLevel();
    // SceneController.instance.LoadScene(nextLevelIndex);

        if (collision.CompareTag("Player"))
        {
            //Will take OZ to the next level!
            if(nextLevel)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }
            //AudioManager.Instance.musicSource.Stop(); feature that is able to stop music when progressing to new level
            AudioManager.Instance.PlaySFX("FinishLevel");
        }
    }      
}