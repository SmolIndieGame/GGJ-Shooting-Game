using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IObjectPooled<Bullet>
{
    float damage;

    public PoolHandler<Bullet> poolHandler { get; set; }

    public void Setup(float damage, Vector2 startPos, float startRot)
    {
        this.damage = damage;
        transform.position = startPos;
        transform.eulerAngles = new Vector3(0, 0, startRot);

        RaycastHit2D target = default;
        RaycastHit2D[] raycastHit2Ds = Physics2D.RaycastAll(transform.position, transform.up * 999, 999);
        int i;
        for (i = 0; i < raycastHit2Ds.Length; i++)
        {
            if (raycastHit2Ds[i].collider.attachedRigidbody.CompareTag("Player"))
                continue;

            target = raycastHit2Ds[i];
            break;
        }
        if (i == raycastHit2Ds.Length)
            transform.localScale = new Vector3(1, 100, 1);
        else
        {
            float distance = Vector2.Distance(transform.position, target.point);
            EnemyHealth enemyHealth = target.rigidbody.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(damage, target.normal);
            }
            transform.localScale = new Vector3(1, distance, 1);
        }

        Invoke(nameof(Return), 0.05f);
    }

    void Return()
    {
        poolHandler.Return(this);
    }

    public void OnGet()
    {

    }

    public void OnReturn()
    {

    }
}
