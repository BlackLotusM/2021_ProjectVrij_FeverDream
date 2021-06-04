using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class level2Manager : MonoBehaviour
{
    public List<string> words;
    public TextMeshProUGUI[] fill;
    //public string[] words;
    public Animator anim;
    public bool played;
    public TicketManager tm;

    public void play()
    {
        anim.Play("DoorOpen");
    }
    private void Update()
    {
        if (words.Count > 5)
        {
            foreach(TextMeshProUGUI fill in fill)
            {
                fill.text = "";
            }
            words.Clear();
        }
        for (int i = 0; i < words.Count; i++)
        {
            fill[i].text = words[i];
        }
        if(words.Count == 5)
        {
            if(words[0] == "ACCEPT" && words[1] == "HAUNTED" && words[2] == "CORRIDORS" && words[3] == "YOUR" && words[4] == "BRAIN")
            {
                if (!played)
                {
                    play();
                    played = true;
                    tm.addState();
                }
            }
            else
            {
                words.Clear();
                foreach (TextMeshProUGUI fill in fill)
                {
                    fill.text = "";
                }
            }
        }
    }
    public void addString(string word)
    {
        words.Add(word);
    }
}
