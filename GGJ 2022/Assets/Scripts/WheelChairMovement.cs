using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector2 childOffset;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
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

        
        if(movement.x != 0 & movement.y !=0)
        {
            transform.up = movement;
        }
    }

    void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + movement * movementSpeed * Time.fixedDeltaTime);
        rb3.MovePosition(rb2.position);
        rb.MovePosition(rb3.position + childOffset);
    }
}
