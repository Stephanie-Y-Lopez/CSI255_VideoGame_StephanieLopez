using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//Stephanie Lopez

public class SavingData : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public int level;
    }

    public class SaveSystem : MonoBehaviour
    {
        public void SaveData(PlayerData data)
        {
            string json = JsonUtility.ToJson(data);
           File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
        }

        public PlayerData LoadData()
        {
          string path = Application.persistentDataPath + "/playerData.json";
           if (File.Exists(path))
            {
               string json = File.ReadAllText(path);
               return JsonUtility.FromJson<PlayerData>(json);
            }
           return null;
        }
    }
}
