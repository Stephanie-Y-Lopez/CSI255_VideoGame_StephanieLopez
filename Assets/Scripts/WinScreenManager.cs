using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez

public class WinScreenManager : MonoBehaviour
{
    public void TakeBackToMM()
    {
        Debug.Log("MainMenu button clicked");

        SceneManager.LoadSceneAsync("MainMenu");
    }

    //public void OnLoadButtonClick()
    //{
    //     SceneManager.LoadSceneAsync("MainMenu");
   // }
}
