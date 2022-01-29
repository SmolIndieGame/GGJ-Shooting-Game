using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IObjectPooled<EnemyMovement>
{
    Rigidbody2D rb;

    public float moveSpeed;

    Transform target;

    public PoolHandler<EnemyMovement> poolHandler { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
