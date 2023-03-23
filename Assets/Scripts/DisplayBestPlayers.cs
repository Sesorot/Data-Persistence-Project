using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DisplayBestPlayers : MonoBehaviour
{
    [SerializeField] TMP_Text bestScoresText;

    private void Start()
    {
        DataFlow data = DataFlow.Instance;
        List<string> newList = data.listOfBestPlayers;
        newList.Reverse();
        string[] arrayOfScores = newList.ToArray();
        if (arrayOfScores.Length > 0)
        {
            string stringOfScores = string.Join("\n", arrayOfScores);
            bestScoresText.text = stringOfScores; 
        }
        else
        {
            bestScoresText.text = "No best scores!";
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
