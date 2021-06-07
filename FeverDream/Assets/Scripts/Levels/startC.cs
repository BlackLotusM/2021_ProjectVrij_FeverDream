using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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
    public TicketManager tm;
    public GameObject[] handler;
    public VideoClip clip;
    public VideoPlayer player;
    public Material mat;
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
        }
        else
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

    bool finsh;
    private void Update()
    {
        if (secondLevelActive)
        {
            player.clip = clip;
            foreach (GameObject go in needstobeactive)
            {
                if (go.activeSelf == true)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                if (!finsh)
                {
                    //Debug.Log("gg");
                    if (walls[0].activeSelf == true && walls[1].activeSelf == true)
                    {
                        if (levelcaudio.r1 == true && levelcaudio.r2 == true)
                        {
                            walls[0].gameObject.GetComponentInChildren<MeshRenderer>().material = mat;
                            finsh = true;
                            light.SetActive(true);
                            correctWall.GetComponentInChildren<BoxCollider>().isTrigger = true;
                            border.SetActive(false);
                            tm.addState();
                            foreach (GameObject go in handler)
                            {
                                go.GetComponent<levelCbtnHandler>().disabled = true;
                            }
                        }
                    }
                }
            }
            else
            {
                //Light off 
                //Colider on
                foreach(GameObject go in handler)
                {
                    go.GetComponent<levelCbtnHandler>().disabled = false;
                }
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
                if (walls[0].activeSelf == false && walls[1].activeSelf == false)
                {
                    if (levelcaudio.r1 == false && levelcaudio.r2 == false)
                    {
                        if (!played)
                        {
                            if (anim2.GetCurrentAnimatorStateInfo(0).IsName("New State"))
                            {
                                foreach (GameObject handle in handler)
                                {

                                    handle.GetComponent<levelCbtnHandler>().disabled = true;
                                }
                                anim2.Play("DoorOpen");
                                played = true;
                                tm.addState();
                            }
                        }
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
