using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez

public class WinScreenManager : MonoBehaviour
{
    public void TakeBackToMM()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
