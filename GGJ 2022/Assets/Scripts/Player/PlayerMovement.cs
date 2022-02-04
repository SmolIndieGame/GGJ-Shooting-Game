using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    IChildInput input;
    public Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        input = GetComponent<IChildInput>();
    }

    void Update()
    {
        movement.x = input.MovementX;
        movement.y = input.MovementY;

        if (movement != Vector2.zero)
        {
            transform.up = movement;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement.normalized);
    }
}
