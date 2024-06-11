using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Stephanie Lopez
public class DeathScreenManager : MonoBehaviour
{
    public void RestartLevel()
    {
        Scene previousScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 2);
        SceneManager.LoadScene(previousScene.name);
    }
}
