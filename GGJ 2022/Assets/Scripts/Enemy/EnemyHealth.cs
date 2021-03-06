using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy self;
    EnemyMovement movement;

    [Header("Data")]
    public AudioClip[] sound;
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
        ParticlePool.I.SpawnParticle(ParticleType.Blood, transform.position, normal, 0.5f);
        Sounds.I.Play(sound[Random.Range(0, sound.Length)]);

        curLife -= damage;
        self.stasisTimer.Reset();
        movement.AddForce(normal.normalized * -1, knockback);
        if (curLife <= 0)
        {
            ParticlePool.I.SpawnParticle(ParticleType.Die, transform.position, normal, 5);
            //Sounds.I.Play(sound[Random.Range(0, sound.Length)]);

            Scoring.I.Earn();
            self.Return();
        }
    }
}
