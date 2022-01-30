using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{
    [Header("Force")]
    public float accelerationInput;
    Vector2 velo;
    Vector2 force;
    Vector2 brakeForce;

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
        movement.y = Input.GetAxisRaw("Vertical") * -1;

        if (movement != Vector2.zero)
        {
            float angle = movement.x * rotateSpeed;
            transform.Rotate(0,0,angle);
            child.transform.Rotate(0,0,angle);
        }

        if (Input.GetButton("Fire1"))
        {
            PushForward();
        }

        if (Input.GetButton("Brake"))
        {
            //Brake();
        }

        velo = rb.velocity;
    }

    void LateUpdate()
    {
        child.transform.position = (Vector2)transform.TransformPoint(childOffset);
    }

    void PushForward()
    {
        force = (Vector2)transform.up * accelerationInput;
        rb.AddForce(force);
    }

    void Brake()
    {
        if(force != Vector2.zero)
        {
            Debug.Log("Brake");
            brakeForce = (Vector2)transform.up * accelerationInput * -1 * 2;
            rb.AddForce(brakeForce);
        }
    }
}
