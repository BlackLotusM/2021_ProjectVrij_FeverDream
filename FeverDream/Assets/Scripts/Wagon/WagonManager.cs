using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonManager : MonoBehaviour
{
    public Transform pointToSpawn;
    
    public GameObject wagonPrefab;
    public GameObject nextWagonPrefab;
    public GameObject spawnedPrefab;
    public GameObject parentWagon;
    public bool playerTouched;
    public bool firstWagon;
    public bool cleared;
    public bool spawnedNew;

    private void Start()
    {
        playerTouched = false;
        firstWagon = false;
        spawnedNew = false;
        cleared = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<MoveScript>().current = this;
            playerTouched = true;
            
        }
    }

    private void Update()
    {
        if (playerTouched)
        {
            if (!firstWagon)
            {
                DestroyImmediate(parentWagon);
            }
        }

        if(spawnedPrefab == null && playerTouched)
        {
            if (cleared)
            {
                spawnedNew = true;
                GameObject s2 = Instantiate(nextWagonPrefab);
                s2.transform.position = pointToSpawn.position;
                spawnedPrefab = s2;
                s2.GetComponent<WagonManager>().parentWagon = this.gameObject;
                s2.name = nextWagonPrefab.name;
            }
            else
            {
                GameObject s =  Instantiate(wagonPrefab);
                s.transform.position = pointToSpawn.position;
                spawnedPrefab = s;
                s.GetComponent<WagonManager>().parentWagon = this.gameObject;
                s.name = wagonPrefab.name;
            }
        }

        if (cleared && !spawnedNew)
        {
            DestroyImmediate(spawnedPrefab);
            spawnedPrefab = null;
        }
    }
}
