using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pickedUp;
    public GameObject ticket;
    public GameObject canvasTicket;
    public GameObject invulCanvas;
    public GameObject canvasEscape;
    public LookScript lookScript;
    public MoveScript moveScript;
    public GameObject[] rebusZooi;
    public bool skip;
    public int current = 0;
    public Image target;
    public Sprite[] states;
    public GameObject activateTicket;
    int count;

    public void addState()
    {
        current++;
        canvasTicket.SetActive(true);
        activateTicket.SetActive(true);
        moveScript.canMove = false;
        lookScript.canLook = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(current == 1)
        {
            target.sprite = states[0];
        }
        else if (current == 2)
        {
            target.sprite = states[1];
        }
        else if (current == 3)
        {
            target.sprite = states[2];
        }
        else if (current == 4)
        {
            target.sprite = states[3];
        }
        else if (current == 5)
        {
            target.sprite = states[4];
        }
        else if (current == 6)
        {
            target.sprite = states[5];
        }


        count = 0; 
        if (!skip)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canvasTicket.activeSelf)
                {

                }
                else
                {
                    foreach (GameObject go in rebusZooi)
                    {
                        if (go.activeSelf == true)
                        {
                            count++;
                        }
                        moveScript.canMove = true;
                        lookScript.canLook = true;
                        go.SetActive(false);
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }

                    if (count == 0)
                    {
                        if (invulCanvas.activeSelf == true)
                        {
                            invulCanvas.SetActive(false);
                            Cursor.lockState = CursorLockMode.Locked;
                            Cursor.visible = false;
                            moveScript.canMove = true;
                            lookScript.canLook = true;
                        }
                        else
                        {
                            //if (pickedUp)
                            //{
                            //    canvasEscape.SetActive(!canvasEscape.activeSelf);
                            //    canvasTicket.SetActive(canvasEscape.activeSelf);
                            //    lookScript.canLook = !canvasEscape.activeSelf;
                            //    moveScript.canMove = !canvasEscape.activeSelf;
                            //}
                            //else
                            //{
                            //    canvasEscape.SetActive(!canvasEscape.activeSelf);
                            //    canvasTicket.SetActive(false);
                            //    lookScript.canLook = !canvasEscape.activeSelf;
                            //    moveScript.canMove = !canvasEscape.activeSelf;

                            //}

                            if (canvasEscape.activeSelf == true)
                            {
                                Cursor.lockState = CursorLockMode.None;
                                Cursor.visible = true;
                            }
                            else
                            {
                                Cursor.lockState = CursorLockMode.Locked;
                                Cursor.visible = false;
                            }
                        }
                    }
                }
            }
        }
    }

    public void disa()
    {
        canvasEscape.SetActive(false);
        canvasTicket.SetActive(false);
        lookScript.canLook = true;
        moveScript.canMove = true;
    }

    public void interact()
    {
        Destroy(ticket);
        pickedUp = true;
    }
}
