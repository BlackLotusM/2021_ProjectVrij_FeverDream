using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCbtnHandler : MonoBehaviour
{
    public GameObject[] group;
    public GameObject btnPressed;
    public GameObject btnNotPressed;
    public bool pressed;
    public bool disabled;

    public void interact()
    {
        if (!disabled)
        {
            pressed = !pressed;
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

    

