using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPooled
{
    Rigidbody2D rb;

    public float moveSpeed;

    Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        OnGet();
    }

    public void OnGet()
    {
        target = EnemyMovementHandle.I.GetTarget(gameObject).transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * (moveSpeed * Time.fixedDeltaTime));
        transform.up = direction;
    }

    public void OnReturn()
    {

    }
}
