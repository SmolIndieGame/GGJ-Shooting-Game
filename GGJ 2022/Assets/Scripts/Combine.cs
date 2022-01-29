using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public bool isCombinable;
    public GameObject child;
    public GameObject old;

    void Update()
    {
        if (Input.GetKeyUp("joystick button 1") & isCombinable)
        {
            child.GetComponent<PlayerMovement>().enabled = !child.GetComponent<PlayerMovement>().enabled;
            old.GetComponent<WheelChairMovement>().enabled = !old.GetComponent<WheelChairMovement>().enabled;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "WheelChairHandle")
        {
            isCombinable = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
            if(col.gameObject.tag == "WheelChairHandle")
        {
            isCombinable = false;
        }
    }
}
