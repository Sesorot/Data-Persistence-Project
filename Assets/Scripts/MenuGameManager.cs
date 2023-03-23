using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuGameManager : MonoBehaviour
{
    [SerializeField] TMP_Text helloText;
    [SerializeField] TMP_Text nameInput;
    [SerializeField] TMP_Text bestScoreText;

    private void Start()
    {
        LoadDataClicked();
    }

    public void SaveDataClicked()
    {
        DataFlow data = DataFlow.Instance;
        data.playerName = nameInput.text;
        data.SaveData();
    }

    public void LoadDataClicked()
    {
        DataFlow data = DataFlow.Instance;
        data.LoadData();
        if (data.bestPlayer != null && data.bestPlayer != "" && data.maxScore > 0)
        {
            bestScoreText.text = data.bestPlayer + ": " + data.maxScore;
        }
        if (data.playerName != null && data.playerName != "")
        {
            helloText.gameObject.SetActive(true);
            helloText.text = "Hello, " + data.playerName;
        }
        else
        {
            helloText.gameObject.SetActive(false);
        }
    }

    public void ShowBestScores()
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
