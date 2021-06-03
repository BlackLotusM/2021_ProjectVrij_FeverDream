using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public string word;
    public level2Manager manger;
    public void interact()
    {
        manger.addString(word);
    }
}
