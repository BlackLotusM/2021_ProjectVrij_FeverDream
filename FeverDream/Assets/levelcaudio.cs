using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcaudio : MonoBehaviour
{
    [SerializeField]
    public FMODUnity.StudioEventEmitter acceptN;
    [SerializeField]
    public FMODUnity.StudioEventEmitter acceptR;
    [SerializeField]
    public FMODUnity.StudioEventEmitter CorridorN;
    [SerializeField]                    
    public FMODUnity.StudioEventEmitter CorridorR;

    public static bool r1 = true, r2 = true;
    public bool played, allowed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            allowed = true;
            played = true;
            PlaySound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            allowed = false;
        }
    }

    private void Update()
    {
        if (!allowed)
        {
            acceptN.Stop();
            acceptR.Stop();
            CorridorN.Stop();
            CorridorR.Stop();
        }
        if (allowed)
        {
            if (played && !CorridorN.IsPlaying() && played && !CorridorR.IsPlaying())
            {
                PlaySound();
                played = false;
            }

            if (CorridorN.IsPlaying() || CorridorR.IsPlaying())
            {
                played = true;
            }
        }
    }

    public void PlaySound()
    {
        if (allowed)
        {
            if (r1)
            {
                acceptR.Play();
            }
            else
            {
                acceptN.Play();
            }

            if (r2)
            {
                CorridorR.Play();
            }
            else
            {
                CorridorN.Play();
            }
        }
    }
}
