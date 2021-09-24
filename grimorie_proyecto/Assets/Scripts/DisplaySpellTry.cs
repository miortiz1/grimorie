using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DisplaySpellTry : MonoBehaviour
{
    public Text txt;
    public Text txtPop;
    private List<string> words = new List<string>();
    private List<string> mySpells = new List<string>();
    private string spellTry;
    public float time = 0;
    Dictionary<string, string> spells = new Dictionary<string, string>();


    // Start is called before the first frame update
    void Start()
    {
        spellTry = "";
        spells.Add("while mana area hydro", "hydro");
        spells.Add("bullet pyro", "pyro");

        PressButton.ButtonPressed += AddSpellWord;
    }

    private void AddSpellWord(string word)
    {
        if (word == "delete")
        {
            if (words.Count > 0)
            {
                int length = words[words.Count - 1].Length;
                words.RemoveAt(words.Count - 1);
                if (words.Count != 0)
                {
                    txt.text = txt.text.Substring(0, txt.text.Length - (length + 1));
                }
                else
                {
                    txt.text = "";
                }
            }
        }
        else if (word == "try")
        {
            txt.gameObject.SetActive(false);

            if (spells.ContainsKey(txt.text))
            {
                txtPop.text = "¡ Hechizo Desbloqueado !";
                mySpells.Add(spells[txt.text]);
                words.Clear();
                //txt.text = mySpells[0];
                txt.text = "";
                time = 2;
            }
            else
            {
                txtPop.text = "Este hechizo no existe\n¡ Sigue Practicando !";
                time = 2;
            }
        }
        else
        {
            words.Add(word);
            txt.text = String.Join(" ", words.ToArray());
        }
    }

    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            txtPop.text = "";
            txt.gameObject.SetActive(true);
        }    
    }

}
