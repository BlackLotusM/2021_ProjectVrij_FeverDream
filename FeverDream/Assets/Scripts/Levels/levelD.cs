using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelD : MonoBehaviour
{
    public Animator anim;
    public bool played, played2;
    public Animator anim2;
    public GameObject border;
    public PlayerClose door;
    private void OnTriggerEnter(Collider other)
    {
        if (!door.done)
        {
            if (!played)
            {
                played = true;
                anim.Play("DoorOpen");
            }

            if (!played2)
            {
                border.SetActive(true);
                played2 = true;
                anim2.Play("CloseDoor");
            }
        }
    }
}
