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
}
