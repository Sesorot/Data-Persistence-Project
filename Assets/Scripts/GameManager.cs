using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        isPaused = !isPaused;
    }
}
