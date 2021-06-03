using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pickedUp;
    public GameObject ticket;
    public GameObject canvasTicket;
    public GameObject invulCanvas;
    public GameObject canvasEscape;
    public LookScript lookScript;
    public MoveScript moveScript;
    public GameObject[] rebusZooi;
    public bool skip;
    int count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = 0; 
        if (!skip)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
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
                        if (pickedUp)
                        {
                            canvasEscape.SetActive(!canvasEscape.activeSelf);
                            canvasTicket.SetActive(canvasEscape.activeSelf);
                            lookScript.canLook = !canvasEscape.activeSelf;
                            moveScript.canMove = !canvasEscape.activeSelf;
                        }
                        else
                        {
                            canvasEscape.SetActive(!canvasEscape.activeSelf);
                            canvasTicket.SetActive(false);
                            lookScript.canLook = !canvasEscape.activeSelf;
                            moveScript.canMove = !canvasEscape.activeSelf;

                        }

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

    public void interact()
    {
        Destroy(ticket);
        pickedUp = true;
    }
}
