using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public bool isCombinable;

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
