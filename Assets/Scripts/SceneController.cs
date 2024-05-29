using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    //public GameObject gameOverOz;<IsDeadScreen

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    // public void gameOver()<IsDeadScreen
    // {
    //     gameOverOz.SetActive(true);
    // }
}