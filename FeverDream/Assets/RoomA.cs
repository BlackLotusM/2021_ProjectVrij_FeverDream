using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomA : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        anim.Play("DoorOpen");
    }
}
