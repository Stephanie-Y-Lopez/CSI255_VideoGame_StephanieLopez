using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez
public class DeathScreenManager : MonoBehaviour
{

    SceneController sc;
    public int currentIndex;
    private void Start() {
        sc = FindObjectOfType<SceneController>();
        currentIndex = sc.currentScene;
    }

    public void RestartLevel()
    {
        //Get the index of died on level
        //  int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log(currentSceneIndex);


        //Scene previousScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 2);
        
        SceneManager.LoadScene(currentIndex);
    }
}
