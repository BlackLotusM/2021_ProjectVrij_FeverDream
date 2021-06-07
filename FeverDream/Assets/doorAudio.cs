using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public FMODUnity.StudioEventEmitter open;
    [SerializeField]
    public FMODUnity.StudioEventEmitter close;
    

    public void Open()
    {
        open.Play();
    }

    public void Close()
    {
        close.Play();
    }
}
