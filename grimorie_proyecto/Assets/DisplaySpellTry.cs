using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplaySpellTry : MonoBehaviour
{
    public Text txt;
    private List<string> words = new List<string>();
    private string spellTry;
    
    // Start is called before the first frame update
    void Start()
    {
        spellTry = "";

        PressButton.ButtonPressed += AddSpellWord;
    }

    private void AddSpellWord(string word)
    {
        words.Add(word);
        txt.text = String.Join(" ", words.ToArray());
    }

}
