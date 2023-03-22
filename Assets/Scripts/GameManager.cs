using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] TMP_Text pauseText;
    [SerializeField] GameObject pausePanel;

    private void Start()
    {
        isPaused = false;
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            pauseText.text = "Unpause";
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseText.text = "Pause";
            pausePanel.SetActive(false);
        }
        isPaused = !isPaused;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
