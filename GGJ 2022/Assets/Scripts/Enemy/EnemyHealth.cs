using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy self;
    EnemyMovement movement;

    [Header("Data")]
    public float knockback;

    [Header("Current")]
    float curLife;

    private void Awake()
    {
        self = GetComponent<Enemy>();
        movement = GetComponent<EnemyMovement>();
    }

    public void Init()
    {
        curLife = DifficultyController.I.enemyHealth;
    }

    public void Damage(float damage, Vector2 normal)
    {
        curLife -= damage;
        self.stasisTimer.Reset();
        movement.AddForce(normal.normalized * -1, knockback);
        if (curLife <= 0)
        {
            Scoring.I.Earn();
            self.Return();
        }
    }
}
