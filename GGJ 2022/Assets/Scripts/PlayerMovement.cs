using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Camera cam;
    
    public Vector2 mousePos;
    public Vector2 lookDir;

    public float angle;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        if(movement.x != 0 & movement.y !=0)
        {
            transform.up = movement;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }
}
