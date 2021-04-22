using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAtNoMovement : MonoBehaviour
{
    public Image imageFade;
    private Vector3 lastPosition = new Vector3(0, 0, 0);
    public float fadeOutSpeed, fadeInSpeed;
    public bool initialMove;

    private void Start()
    {
        initialMove = false;
        lastPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            initialMove = true;
        }

        if (initialMove)
        {
            if (lastPosition == gameObject.transform.position)
            {
                if (imageFade.color.a < 1)
                {
                    Color temp = imageFade.color;
                    temp.a = temp.a + fadeOutSpeed;
                    imageFade.color = temp;
                }
                else
                {
                    Color temp = imageFade.color;
                    temp.a = 1;
                    imageFade.color = temp;
                }

            }
            else
            {
                if (imageFade.color.a > 0)
                {
                    Color temp = imageFade.color;
                    temp.a = temp.a - fadeInSpeed;
                    imageFade.color = temp;
                }
                else
                {
                    Color temp = imageFade.color;
                    temp.a = 0;
                    imageFade.color = temp;
                }
            }

            lastPosition = gameObject.transform.position;
        }
    }
}
