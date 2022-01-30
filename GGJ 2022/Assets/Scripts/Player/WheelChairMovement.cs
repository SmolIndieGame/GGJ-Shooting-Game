using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{
    [Header("Testing force")]
    public Vector2 accelerationFactor;
    public float accelerationInput;
    public Vector2 force;

    [Header("WheelChairMovement")]
    public float rotateSpeed;
    public float movementSpeed = 5f;
    public Vector2 childOffset;
    public GameObject child;
    public Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * -1;
        //movement.y = Input.GetAxisRaw("Vertical") * -1;

        if (movement != Vector2.zero)
        {
            float angle = movement.x * rotateSpeed;
            transform.Rotate(0,0,angle);
            child.transform.up = movement;
        }

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("test");
            PushForward();
        }
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement.normalized);
        //PushForward();
    }

    void LateUpdate()
    {
        child.transform.position = (Vector2)transform.TransformPoint(childOffset);
    }

    void PushForward()
    {
        Debug.Log("Apply force");
        force = (Vector2)transform.up * accelerationInput;
        Debug.Log(force);
        rb.AddForce(force);
    }
}
