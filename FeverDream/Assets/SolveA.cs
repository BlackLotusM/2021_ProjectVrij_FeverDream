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

    public Animator anim;

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

    public void Solve()
    {
        //string.Equals(val, "astringvalue", StringComparison.OrdinalIgnoreCase)
        string text = invulVeld.text;
        text = String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
        Debug.Log(text);

        if (string.Equals(text, "don'tletyourmindescape", StringComparison.OrdinalIgnoreCase) || string.Equals(text, "dontletyourmindescape", StringComparison.OrdinalIgnoreCase))
        {
            invulDing.SetActive(false);
            play();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            lookScript.canLook = true;
            moveScript.canMove = true;
        }
    }
}
