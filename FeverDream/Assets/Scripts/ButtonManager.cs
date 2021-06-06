using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public string word;
    public level2Manager manger;
    [FMODUnity.EventRef]
    public string button;
    public void interact()
    {
        FMODUnity.RuntimeManager.PlayOneShot(button, this.transform.position);
        manger.addString(word);
    }
}
