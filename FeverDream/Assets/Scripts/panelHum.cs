﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelHum : MonoBehaviour
{
    // Start is called before the first frame update
    [FMODUnity.EventRef]
    public string hum;
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(hum, GetComponent<Transform>().position);
        FMODUnity.RuntimeManager.PlayOneShotAttached(hum, this.gameObject);
    }

}