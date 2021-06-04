using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fadeText : MonoBehaviour
{
    private void Update()
    {
        
        if (this.GetComponent<TMP_Text>().color.a > 0)
        {
            this.GetComponent<TMP_Text>().color = new Color(this.GetComponent<TMP_Text>().color.r, this.GetComponent<TMP_Text>().color.g, this.GetComponent<TMP_Text>().color.b, this.GetComponent<TMP_Text>().color.a - 0.7f * Time.deltaTime);
        }
    }
}
