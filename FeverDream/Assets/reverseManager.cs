using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class reverseManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public FMODUnity.StudioEventEmitter reverse;
    [SerializeField]
    public FMODUnity.StudioEventEmitter normal;
    public GameObject player;
    public float range;
    public float count;
    public TMP_Text text;
    public Transform respawn;
    public FadeAtNoMovement dm;
    void Start()
    {
        reverse.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, range);
    }
    // Update is called once per frame
    void Update()
    {
        if(count > 18)
        {
            Debug.Log("test");
            count = 0;
            dm.initialMove = false;
            Color temp = dm.imageFade.color;
            temp.a = 0;
            dm.imageFade.color = temp;
            dm.cam.transform.position = new Vector3(dm.cam.transform.position.x, dm.height, dm.cam.transform.position.z);
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = respawn.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            count = 0;
        }
        if (count < 6)
        {
            if (text.color.a > 0)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 14.37f * Time.deltaTime);
            }
        }

        if (Vector3.Distance(this.transform.position, player.transform.position) <= range)
        {
            count += Time.deltaTime;
            if(count < 6)
            {
                normal.Stop();

                if (!reverse.IsPlaying())
                {
                    reverse.Play();    
                }
            }
            else
            {
                if (text.color.a < 0.17f)
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + 0.37f * Time.deltaTime);
                }
                if (!normal.IsPlaying())
                {
                    
                    reverse.Stop();
                    normal.Play();
                }
            }
        }
        else
        {
            count = 0;
            normal.Stop();
            reverse.Stop();
        }
    }
}
