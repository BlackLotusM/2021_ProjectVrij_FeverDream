using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SolveA : MonoBehaviour
{
    public GameObject invulDing;
    public TMP_InputField invulVeld;
    public LookScript lookScript;
    public MoveScript moveScript;
    public RoomA roomA;
    public TicketManager tm;
    public Animator anim;
    public TMP_Text text2;

    public void play()
    {
        anim.Play("DoorOpen");
    }
    public void interact()
    {
        invulDing.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lookScript.canLook = false;
        moveScript.canMove = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("te");
            text2.color = new Color32(1,1,1,0);
        }
    }

    public void Solve()
    {
        //string.Equals(val, "astringvalue", StringComparison.OrdinalIgnoreCase)
        string text = invulVeld.text;
        text = String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
        Debug.Log(text);

        if (string.Equals(text, "don'tletyourmindescape", StringComparison.OrdinalIgnoreCase) || string.Equals(text, "dontletyourmindescape", StringComparison.OrdinalIgnoreCase))
        {
            if (tm.pickedUp == true)
            {
                invulDing.SetActive(false);
                play();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                lookScript.canLook = true;
                moveScript.canMove = true;
                tm.addState();
            }
            else
            {
                
                text2.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
