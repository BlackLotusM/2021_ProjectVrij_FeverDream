using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public MoveScript move;
    public LookScript look;
    public Image image;
    public TicketManager tm;
    private void OnTriggerEnter(Collider other)
    {
        move.canMove = false;
        look.canLook = false;
        StartCoroutine(test());
        tm.skip = true;

        Debug.Log("test");
    }

    IEnumerator test()
    {
        while (image.color.a < 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (0.1f * Time.deltaTime));
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log("ree");
    }
}
