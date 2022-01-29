using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public Vector2 mousePos;
    public Camera cam;
    public Rigidbody2D rb;

    public Vector2 currentPosition;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentPosition = transform.position;
        transform.up = mousePos - currentPosition;
    }

    void FixedUpdate()
    {
        
    }
}
