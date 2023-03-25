using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public Color[] availableColors;
    public Button colorButtonPrefab;

    public Color selectedColor { get; private set; }
    public System.Action<Color> onColorChanged;

    List<Button> m_colorButtons = new List<Button>();

    public void Init()
    {
        foreach (var color in availableColors)
        {
            var newButton = Instantiate(colorButtonPrefab, transform, false);
            var newColor = color;
            newColor.a = 1f;
            newButton.GetComponent<Image>().color = newColor;

            newButton.onClick.AddListener(() =>
            {
                selectedColor = color;
                foreach (var button in m_colorButtons)
                {
                    button.interactable = true;
                }

                newButton.interactable = false;

                onColorChanged.Invoke(selectedColor);
            });

            m_colorButtons.Add(newButton);
        }
    }

    public void SelectColor(Color color)
    {
        for (int i = 0; i < availableColors.Length; ++i)
        {
            if (availableColors[i] == color)
            {
                m_colorButtons[i].onClick.Invoke();
            }
        }
    }
}
