using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IObjectPooled
{
    float damage;

    public void Setup(float damage)
    {
        this.damage = damage;
    }

    public void OnGet()
    {
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

        float distance = Vector2.Distance(transform.position, targetPoint);
        //transform.position += transform.up * distance / 2;
        transform.localScale = new Vector3(1, distance, 1);
    }

    public void OnReturn()
    {

    }
}
