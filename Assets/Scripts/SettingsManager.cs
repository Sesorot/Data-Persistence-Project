using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public ColorPicker colorPicker;

    public void NewColorSelected(Color color)
    {
        DataFlow.Instance.trailColorInGame = color;
    }

    private void Start()
    {
        colorPicker.Init();
        colorPicker.onColorChanged += NewColorSelected;
        colorPicker.SelectColor(DataFlow.Instance.trailColorInGame);
    }

    public void BackToMenu()
    {
        DataFlow.Instance.SaveData();
        SceneManager.LoadScene(0);
    }
}
