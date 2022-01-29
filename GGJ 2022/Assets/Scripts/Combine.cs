using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public bool isCombinable;
    public bool combined;
    public GameObject child;
    public GameObject old;

    void Update()
    {
        if (Input.GetKeyUp("joystick button 0") & isCombinable)
        {
            print("Combine");
            //combined = true;
            child.GetComponent<PlayerMovement>().enabled = !child.GetComponent<PlayerMovement>().enabled;
            old.GetComponent<WheelChairMovement>().enabled = !old.GetComponent<WheelChairMovement>().enabled;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            isCombinable = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
            if(col.gameObject.tag == "Player")
        {
            isCombinable = false;
        }
    }
}
