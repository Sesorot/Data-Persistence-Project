using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    public GameObject ballGO;

    public Text ScoreText;
    public Text bestScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        LoadBestScore();
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{DataFlow.Instance.playerName}'s score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        DataFlow data = DataFlow.Instance;
        if (m_Points > data.maxScore)
        {
            data.maxScore = m_Points;
            DataFlow.Instance.SaveData();
        }
        LoadBestScore();
    }

    private void LoadBestScore()
    {
        DataFlow data = DataFlow.Instance;
        data.LoadData();
        if (data.bestPlayer != null && data.bestPlayer != "")
        {
            bestScoreText.text = $"Best Score : {data.bestPlayer} : {data.maxScore}"; 
        }
        else
        {
            bestScoreText.text = "No best score. Be first!";
        }
        ScoreText.text = $"{data.playerName}'s score : {m_Points}";
        ballGO.gameObject.GetComponent<TrailRenderer>().material.color = data.trailColorInGame;
        ballGO.GetComponent<MeshFilter>().sharedMesh = data.meshInGame.sharedMesh;

        //DataFlow.Data data = new();
        //currentPlayerName = data.currentPlayer;
        //if (data.maxScore > 0)
        //{
        //    bestScoreText.text = $"Best Score : {data.bestPlayerName} : {data.maxScore}";
        //}
    }
}
