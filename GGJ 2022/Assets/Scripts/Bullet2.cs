using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour, IObjectPooled<Bullet2>
{
    public new Collider2D collider;

    float damage;
    bool used;

    public PoolHandler<Bullet2> poolHandler { get; set; }

    public void Setup(float damage, Vector2 startPos, float startRot)
    {
        this.damage = damage;
        transform.position = startPos;
        transform.eulerAngles = new Vector3(0, 0, startRot);
    }

    private void Update()
    {
        if (used) return;

        List<Collider2D> touchedColliders = new List<Collider2D>();
        Physics2D.OverlapCollider(collider, new ContactFilter2D(), touchedColliders);

        for (int i = 0; i < touchedColliders.Count; i++)
        {
            Rigidbody2D rb = touchedColliders[i].attachedRigidbody;
            if (rb == null || !rb.CompareTag("Enemy"))
                continue;

            EnemyHealth enemyHealth = touchedColliders[i].attachedRigidbody.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(damage, (touchedColliders[i].transform.position - transform.position).normalized);
            }
        }

        Invoke(nameof(Return), 0.05f);
    }

    void Return()
    {
        poolHandler.Return(this);
    }

    public void OnGet() { used = false; }
    public void OnReturn() { }
}
