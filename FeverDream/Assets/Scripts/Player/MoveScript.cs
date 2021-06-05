using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    //Movement related
    [Header("Movement")]
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public bool canMove;
    //Jump
    public float jumpHeight = 3f;

    //Ground Check
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;

    //Active next wagon
    public WagonManager current;

    [Header("Croshair")]
    public float hitDistance;
    Ray ray;
    RaycastHit hit;
    public Image croshairPlaceholder;
    public Sprite interactSprite;
    public Sprite standardSprite;
    public TicketManager ticketManager;
    public GameObject[] rebusDingen;
    public LookScript lookScript;
    public FadeAtNoMovement lvl2Mech;

    [FMODUnity.EventRef]
    public string steps;
    [FMODUnity.EventRef]
    public string ticket;
    public void stepSound()
    {
        if (canMove)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot(steps);
            }
        }
    }

    private void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/trein1_standup", GetComponent<Transform>().position);
        InvokeRepeating("stepSound", 0, 0.5f);

    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            float hoverError = hitDistance - hit.distance;
            if (hoverError > 0)
            {
                if (hit.collider.tag == "Interactable")
                {
                    croshairPlaceholder.sprite = interactSprite;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if(hit.collider.name == "Ticket")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot(ticket);
                            ticketManager.interact();
                            ticketManager.addState();
                        }

                        if (hit.collider.name == "btn")
                        {
                            hit.collider.GetComponent<ButtonManager>().interact();
                        }

                        if (hit.collider.name == "Button")
                        {
                            hit.collider.GetComponent<levelCbtnHandler>().interact();
                        }

                        if (hit.collider.name == "SolveA")
                        {
                            hit.collider.GetComponent<SolveA>().interact();
                        }

                        if (hit.collider.name == "Rebus_1")
                        {
                            canMove = false;
                            lookScript.canLook = false;
                            rebusDingen[0].SetActive(true);
                        }

                        if (hit.collider.name == "Rebus_2")
                        {
                            canMove = false;
                            lookScript.canLook = false;
                            rebusDingen[1].SetActive(true);
                        }

                        if (hit.collider.name == "Rebus_3")
                        {
                            canMove = false;
                            lookScript.canLook = false;
                            rebusDingen[2].SetActive(true);
                        }

                        if (hit.collider.name == "Rebus_4")
                        {
                            canMove = false;
                            lookScript.canLook = false;
                            rebusDingen[3].SetActive(true);
                        }

                        if (hit.collider.name == "Rebus_5")
                        {
                            canMove = false;
                            lookScript.canLook = false;
                            rebusDingen[4].SetActive(true);
                        }
                    }
                }
                else
                {
                    croshairPlaceholder.sprite = standardSprite;
                }
            }
            else
            {
                croshairPlaceholder.sprite = standardSprite;
            }
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (canMove)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Sets Current wagon to the room you are in
        if(collision.gameObject.GetComponent<WagonManager>())
        {
            current = collision.gameObject.GetComponent<WagonManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lvl2")
        {
            lvl2Mech.enabled = true;
        }
        else
        {
            lvl2Mech.enabled = false;
            lvl2Mech.imageFade.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "lvl3")
        {
            lvl2Mech.enabled = true;
        }
    }
}
