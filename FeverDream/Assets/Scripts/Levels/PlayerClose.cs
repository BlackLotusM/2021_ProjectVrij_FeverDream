using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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
    public TicketManager tm;
    public levelCbtnHandler btn;
    public VideoPlayer vidPlayer;
    public VideoClip clip;
    

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
            vidPlayer.clip = clip;
            c.secondLevelActive = true;
            started = true;
            yield return new WaitForSeconds(2);
            anim.Play("CloseDoor");
            backDoor.Play("DoorOpen");
            backDoorCol.SetActive(false);
            tm.moveScript.disableWobbel = true;
            done = true;
            tm.addState();
            btn.second = true;
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
