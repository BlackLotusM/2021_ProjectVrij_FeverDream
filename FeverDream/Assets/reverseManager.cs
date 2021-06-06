using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        reverse.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            count = 0;
        }
        if (Vector3.Distance(this.transform.position, player.transform.position) <= range)
        {
            count += Time.deltaTime;
            if(count < 6)
            {
                if (!reverse.IsPlaying())
                {
                    reverse.Play();
                    normal.Stop();
                }
            }
            else
            {
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
