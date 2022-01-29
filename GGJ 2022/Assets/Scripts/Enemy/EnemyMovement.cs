using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Enemy self;
    Rigidbody2D rb;

    float moveSpeed;

    Transform target;

    private void Awake()
    {
        self = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        target = EnemyMovementHandle.I.GetTarget(gameObject).transform;
    }

    public void Init()
    {
        moveSpeed = DifficultyController.I.enemySpeed;
    }

    private void FixedUpdate()
    {
        transform.up = target.position - transform.position;
        if (self.stasisTimer.TimeOut)
        {
            rb.MovePosition(rb.position + (Vector2)transform.up * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    public void AddForce(Vector2 dir, float power)
    {
        rb.AddForce(dir * power);
    }
}
