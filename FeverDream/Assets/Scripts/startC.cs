using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startC : MonoBehaviour
{
    [Header("Part 1")]
    public GameObject[] walls;
    public bool walkedIn, walkedIn2;
    public Animator anim;
    public Animator anim2;
    public bool secondLevelActive;
    public bool played;
    public GameObject[] needstobeactive;
    int count;
    public GameObject col;
    public GameObject correctWall;
    public GameObject light;
    public GameObject border;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (secondLevelActive)
        {
            if (!walkedIn2)
            {
                col.SetActive(true);
                anim2.Play("CloseDoor");
                walkedIn2 = true;
            }
        }else
        if (!walkedIn)
        {
            anim.Play("CloseDoor");
            foreach (GameObject go in walls)
            {
                go.SetActive(true);
            }
            walkedIn = true;
        }
    }

    private void Update()
    {
        if (secondLevelActive)
        {
            foreach (GameObject go in needstobeactive)
            {
                if (go.activeSelf == true)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                //SetLight onn
                //Disable collider
                light.SetActive(true);
                correctWall.GetComponentInChildren<BoxCollider>().isTrigger = true;
                border.SetActive(false);
            }
            else
            {
                //Light off 
                //Colider on
                light.SetActive(false);
                correctWall.GetComponentInChildren<BoxCollider>().isTrigger = false;
            }
            count = 0;
        }
        else
        {
            foreach (GameObject go in needstobeactive)
            {
                if (go.activeSelf == false)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                //Debug.Log("gg");
                if (!played)
                {
                    if (anim2.GetCurrentAnimatorStateInfo(0).IsName("New State"))
                    {
                        anim2.Play("DoorOpen");
                        played = true;
                    }
                }
            }
            else
            {
                if (played)
                {
                    if (anim2.GetCurrentAnimatorStateInfo(0).IsName("New State"))
                    {
                        anim2.Play("CloseDoor");
                        played = false;
                    }
                }
            }
            count = 0;
        }
    }
}
