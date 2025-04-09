using System;
using System.IO;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public string playerInput;
    public string highestScorePlayer;
    public int highestScore;

    private void Awake()
    {
        LoadJsonData();
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(instance);
    }
    [Serializable]
    class SaveData
    {
     public string playerInput;
     public string highestScorePlayer;
     public int highestScore;
    }
    public void SaveJsonData()
    {
        SaveData data = new SaveData();
        data.playerInput = playerInput;
        data.highestScorePlayer = highestScorePlayer;
        data.highestScore = highestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/breakballdata.json", json);
    }
    public void LoadJsonData()
    {
        string path = Application.persistentDataPath + "/breakballdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerInput = data.playerInput;
            highestScore = data.highestScore;
            highestScorePlayer = data.highestScorePlayer;
        }

    }
}
