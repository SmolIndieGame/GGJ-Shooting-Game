using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Enemy self;
    Rigidbody2D rb;

    public float moveSpeed;

    Transform target;

    private void Awake()
    {
        self = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        target = EnemyMovementHandle.I.GetTarget(gameObject).transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        if (self.stasisTimer.TimeOut)
        {
            rb.MovePosition(rb.position + direction * (moveSpeed * Time.fixedDeltaTime));
            transform.up = direction;
        }
    }

    public void AddForce(Vector2 dir, float power)
    {
        rb.AddForce(dir * power);
    }
}
