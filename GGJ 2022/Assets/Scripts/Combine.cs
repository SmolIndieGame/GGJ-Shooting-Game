using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public bool isCombinable;
    public bool wheelMode;
    public PlayerMovement child;
    public WheelChairMovement old;

    public Collider2D childCol;

    void Update()
    {
        if (Input.GetKeyUp("joystick button 1"))
        {
            if(wheelMode){
                SwithControl();
                wheelMode = false;
            }

            if(isCombinable){
                SwithControl();
                wheelMode = true;
            }

        }
    }

    void OnTriggerStay2D(Collider2D col)
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

    void SwithControl()
    {
        child.enabled = !child.enabled;
        old.enabled = !old.enabled;
        childCol.enabled = !childCol.enabled;
    }
}
