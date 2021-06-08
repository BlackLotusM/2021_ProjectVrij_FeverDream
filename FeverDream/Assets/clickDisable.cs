using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDisable : MonoBehaviour
{
    // Start is called before the first frame update
    public MoveScript ms;
    public LookScript ls;
    public bool startedUp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ms.canMove = true;
            ls.canLook = true;
        }
    }
}
