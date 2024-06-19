using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//Stephanie Lopez

public class MMSavingdatabtn : MonoBehaviour
{
    public Text savedDataText; // Assign this in the Unity Editor to a Text component in your main menu UI
    public SceneController sc;
    private SavingData.SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = new SavingData.SaveSystem();
        sc = FindFirstObjectByType<SceneController>();
    }


    public void OnLoadButtonClick()
    {
    string path = Application.persistentDataPath + "/playerData.json";
        
        if (File.Exists(path))
        {
            SavingData.PlayerData data = saveSystem.LoadData();
            sc.LoadScene(data.level);
        }
        else
        {
            Debug.Log("No File Found :(");
        }
    }

    public SavingData.PlayerData LoadData()
        {
            string path = Application.persistentDataPath + "/playerData.json";
 
           if (File.Exists(path))
            {
               string json = File.ReadAllText(path);
               return JsonUtility.FromJson<SavingData.PlayerData>(json);
            }
           return null;
        }
}
