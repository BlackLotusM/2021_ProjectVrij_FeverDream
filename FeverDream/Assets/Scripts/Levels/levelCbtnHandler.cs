using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCbtnHandler : MonoBehaviour
{
    public bool toggleAccept, corridor;
    public GameObject[] group;
    public GameObject btnPressed;
    public GameObject btnNotPressed;
    public bool pressed;
    public bool disabled;

    public static bool accept;
    public static bool cor;

    public bool reset, second;

    public GameObject[] active;
    public GameObject[] inactive;
    public levelCbtnHandler[] buttons;
    public levelCbtnHandler[] buttonsSecond;

    [FMODUnity.EventRef]
    public string button;

    public void interact()
    {
        if (!disabled)
        {
            FMODUnity.RuntimeManager.PlayOneShot(button, this.transform.position);
            if (reset)
            {
                if (second)
                {
                    levelcaudio.r1 = false;
                    levelcaudio.r2 = false;
                    foreach (levelCbtnHandler btn in buttonsSecond)
                    {
                        btn.disabled = false;
                        btn.pressed = true;
                        btn.updateSate();
                    }
                    foreach (GameObject go in active)
                    {
                        go.SetActive(false);
                    }

                    foreach (GameObject go in inactive)
                    {
                        go.SetActive(true);
                    }
                }
                else
                {
                    levelcaudio.r1 = true;
                    levelcaudio.r2 = true;
                    foreach (levelCbtnHandler btn in buttons)
                    {
                        btn.disabled = false;
                        btn.pressed = false;
                        btn.updateSate();
                    }
                    foreach (GameObject go in active)
                    {
                        go.SetActive(true);
                    }

                    foreach (GameObject go in inactive)
                    {
                        go.SetActive(false);
                    }
                }
            }
            else
            {

                pressed = !pressed;
                if (corridor)
                {
                    levelcaudio.r2 = !levelcaudio.r2;
                }

                if (toggleAccept)
                {
                    levelcaudio.r1 = !levelcaudio.r1;
                }

                foreach (GameObject go in group)
                {
                    go.SetActive(!go.activeSelf);
                }

                if (pressed)
                {
                    btnPressed.SetActive(true);
                    btnNotPressed.SetActive(false);
                }
                else
                {
                    btnPressed.SetActive(false);
                    btnNotPressed.SetActive(true);
                }
            }
        }
    }

    public void updateSate()
    {
        if (pressed)
        {
            btnPressed.SetActive(true);
            btnNotPressed.SetActive(false);
        }
        else
        {
            btnPressed.SetActive(false);
            btnNotPressed.SetActive(true);
        }
    }
    }

    

