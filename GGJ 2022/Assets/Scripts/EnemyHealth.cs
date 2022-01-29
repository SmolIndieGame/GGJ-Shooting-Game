using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy self;
    EnemyMovement movement;
    GameObject score;

    [Header("Data")]
    public float maxLife;
    public float knockback;

    [Header("Current")]
    float curLife;

    private void Awake()
    {
        self = GetComponent<Enemy>();
        movement = GetComponent<EnemyMovement>();
        score = GameObject.Find("Score");
    }

    public void Init()
    {
        curLife = maxLife;
    }

    public void Damage(float damage, Vector2 normal)
    {
        curLife -= damage;
        self.stasisTimer.Reset();
        movement.AddForce(normal.normalized * (-1), knockback);
        if (curLife <= 0)
        {
            self.Return();
            score.GetComponent<Scoring>().Earn();
        }
    }
}
