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
    [SerializeField]
    public FMODUnity.StudioEventEmitter emitter;
    public MoveScript ms;
    public TicketManager tm;
    public Camera cam;
    public float height;
    public float intense;
    
    private void Start()
    {
        initialMove = false;
        lastPosition = gameObject.transform.position;
        height = cam.transform.position.y;
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
            if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                if (!emitter.IsPlaying())
                {
                    emitter.Play();
                    Debug.Log("dah");
                }

                if (!ms.wobbel.IsPlaying())
                {
                    ms.wobbel.Play();
                    Debug.Log("dah");
                }

                if (cam.transform.position.y > 0.8f)
                {
                    if (tm.current <= 2)
                    {
                        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 0.1f * Time.deltaTime, cam.transform.position.z);
                    }
                    else
                    {
                        if (cam.transform.position.y < height)
                        {
                            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.8f * Time.deltaTime, cam.transform.position.z);
                        }
                    }
                    if (intense < 1)
                    {
                        intense += (float)0.1f * Time.deltaTime;
                        ms.wobbel.SetParameter("train1_intensity", intense);
                    }
                }
                
            }
            else
            {
                if (cam.transform.position.y < height)
                {
                    cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.8f * Time.deltaTime, cam.transform.position.z);
                    if (intense > 0)
                    {
                        intense -= (float)0.4f * Time.deltaTime;
                        ms.wobbel.SetParameter("train1_intensity", intense);
                    }
                }
                emitter.Stop();
            }
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
