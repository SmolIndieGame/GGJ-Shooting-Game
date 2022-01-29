using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Vector2 childOffset;
    public GameObject child;
    public Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            transform.up = movement;
            child.transform.up = movement;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement.normalized);
    }

    void LateUpdate()
    {
        child.transform.position = (Vector2)transform.TransformPoint(childOffset);
    }
}
