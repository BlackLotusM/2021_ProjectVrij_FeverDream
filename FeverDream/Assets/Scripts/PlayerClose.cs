using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClose : MonoBehaviour
{
    public GameObject player;
    public bool started;
    public Animator anim;
    public Animator backDoor;
    public GameObject backDoorCol;
    public bool done;
    public float x;
    public float z;
    Coroutine test;
    public startC c;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 5)
        {
            if (x == 0 && z == 0)
            {
                if (!started)
                {
                    test = StartCoroutine(startCounting());
                }
            }
            else
            {
                if (test != null)
                {
                    StopCoroutine(test);
                    started = false;
                }
            }
        }
        else
        {
            if (test != null)
            {
                StopCoroutine(test);
                started = false;
            }
        }
    }

    public IEnumerator startCounting()
    {
        if (!done)
        {
            c.secondLevelActive = true;
            started = true;
            yield return new WaitForSeconds(2);
            anim.Play("CloseDoor");
            backDoor.Play("DoorOpen");
            backDoorCol.SetActive(false);
            done = true;
        }
        else
        {
            if (test != null)
            {
                StopCoroutine(test);
            }
        }
    }
}
