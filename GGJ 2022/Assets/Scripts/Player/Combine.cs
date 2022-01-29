using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public bool isCombinable;
    public bool wheelMode;
    public PlayerMovement child;
    public WheelChairMovement old;
    public PlayerPickUpBullet childHand;
    public PlayerBulletHandle bulletBag;

    public Collider2D childCol;

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (wheelMode)
            {
                SwitchControl();
                wheelMode = false;
            }
            else if (isCombinable)
            {
                SwitchControl();
                wheelMode = true;
            }

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("WheelChairHandle"))
        {
            isCombinable = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("WheelChairHandle"))
        {
            isCombinable = false;
        }
    }

    void SwitchControl()
    {
        child.enabled = !child.enabled;
        old.enabled = !old.enabled;
        childCol.enabled = !childCol.enabled;

        if (childHand.HasBullet)
            bulletBag.AddBullet();
        childHand.HasBullet = false;
        childHand.canPickUpBullet = !childHand.canPickUpBullet;
    }
}