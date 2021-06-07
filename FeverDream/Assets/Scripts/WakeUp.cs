using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Image blackScreen;
    public MoveScript moveScript;
    public LookScript lookScript;
    public bool done;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            Color col = blackScreen.color;
            if (col.a > 0.002f)
            {
                blackScreen.color = new Color(col.r, col.g, col.b, col.a - (float)(1 * Time.deltaTime));
            }
            else
            {
                done = true;
                moveScript.canMove = true;
                lookScript.canLook = true;
            }
        }
    }
}
