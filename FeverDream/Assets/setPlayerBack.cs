using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlayerBack : MonoBehaviour
{
    public GameObject door;
    public GameObject doorPos;
    public float spawn;
    public levelD d;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            d.played = false;
            door.transform.position = doorPos.transform.position;
            Debug.Log(other.tag);
            other.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - spawn);
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
