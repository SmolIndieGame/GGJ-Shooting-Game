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

        Vector2 targetPoint = default;
        RaycastHit2D[] raycastHit2Ds = Physics2D.RaycastAll(transform.position, transform.up * 999, 999);
        int i;
        for (i = 0; i < raycastHit2Ds.Length; i++)
        {
            if (raycastHit2Ds[i].collider.attachedRigidbody.CompareTag("Player"))
                continue;

            targetPoint = raycastHit2Ds[i].point;
            break;
        }
        if (i == raycastHit2Ds.Length)
        {
            //transform.position += transform.up * 5;
            transform.localScale = new Vector3(1, 100, 1);
        }
        else
        {
            float distance = Vector2.Distance(transform.position, targetPoint);
            //transform.position += transform.up * distance / 2;
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
