using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };

    private int deviderPosition;
    private string wordName, wordValue;
    
    void Start()
    {
        wordName = gameObject.name;
        deviderPosition = wordName.IndexOf("_");
        wordValue = wordName.Substring(0, deviderPosition);

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        ButtonPressed(wordValue);
    }
}
