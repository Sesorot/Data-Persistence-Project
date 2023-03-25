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

    public List<string> listOfBestPlayers;
    private int bestScoresMaxCount = 5;

    public Color trailColorInGame;
    public MeshFilter meshInGame;

    [System.Serializable]
    class Data
    {
        public string currentPlayer;
        public string bestPlayerName;
        public int maxScore;
        public List<string> bestPlayers;
        public Color trailColor;
        public MeshFilter mesh;
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
        if (listOfBestPlayers == null)
        {
            listOfBestPlayers = new(); 
        }
        else
        {
            Debug.Log("Local list is not null");
        }
        LoadData();
    }

    public void SaveData()
    {
        Data data = new();

        data.currentPlayer = playerName;
        data.bestPlayerName = bestPlayer;
        data.maxScore = maxScore;
        data.trailColor = trailColorInGame;
        data.mesh = meshInGame;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            data.bestPlayerName = data.currentPlayer;

            string newBestPlayer = playerName + " : " + maxScore;
            if (listOfBestPlayers.Count >= bestScoresMaxCount)
            {
                listOfBestPlayers.RemoveAt(0);
            }
            listOfBestPlayers.Add(newBestPlayer); 
        }

        data.bestPlayers = listOfBestPlayers;

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
            listOfBestPlayers = data.bestPlayers;
            trailColorInGame = data.trailColor;
            meshInGame = data.mesh;
        }
    }
}
