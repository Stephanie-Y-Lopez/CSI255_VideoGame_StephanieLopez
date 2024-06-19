using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public int currentScene;
    //public GameObject gameOverOz;<IsDeadScreen
    public int currentIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if(SceneManager.GetActiveScene().buildIndex != 5) 
            {
                currentScene = SceneManager.GetActiveScene().buildIndex;
            }
        }
        else
        {

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        if(currentScene >= 1 && currentScene <= 3) {
            SaveLevel();
        }
    }

    public void NextLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        // Saving current Level
        Debug.Log("Saving the current level");
        SaveLevel();
    }

    public void StartGame() 
    {
        currentScene = 1;
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    //Added in this load scene to this script because since SceneController is in charge of scene switching, I thought if I passed in these fields it would allow for the index the player last elft of in to be saved?
    public void LoadScene(SceneController sc)
    {
        sc = FindObjectOfType<SceneController>();
        currentIndex = sc.currentScene;
    }

    public void SaveLevel() {
        Debug.Log("Saving Level Data");
        Debug.Log(Application.persistentDataPath);
        SavingData.PlayerData pd = new SavingData.PlayerData() {
            level = currentScene
        };
        SavingData.SaveSystem.SaveData(pd);
    }

    // public void gameOver()<IsDeadScreen
    // {
    //     gameOverOz.SetActive(true);
    // }
}