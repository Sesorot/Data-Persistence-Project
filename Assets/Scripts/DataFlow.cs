using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class DataFlow : MonoBehaviour
{
    public static DataFlow Instance;

    public string playerName;
    public string bestPlayer;
    public int maxScore;

    [System.Serializable]
    class Data
    {
        public string currentPlayer;
        public string bestPlayerName;
        public int maxScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData()
    {
        Data data = new();

        data.currentPlayer = playerName;
        data.bestPlayerName = data.currentPlayer;
        data.maxScore = maxScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveDataBakana.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saveDataBakana.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            playerName = data.currentPlayer;
            bestPlayer = data.bestPlayerName;
            maxScore = data.maxScore;
        }
    }
}
