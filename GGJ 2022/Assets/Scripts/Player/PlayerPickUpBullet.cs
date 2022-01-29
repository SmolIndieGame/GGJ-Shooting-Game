using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpBullet : MonoBehaviour
{
    public bool canPickUpBullet;
    public bool HasBullet;

    private void Start()
    {
        canPickUpBullet = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canPickUpBullet && !HasBullet && collision.CompareTag("BulletItem"))
        {
            collision.gameObject.GetComponent<BulletItem>().Return();
            HasBullet = true;
        }
    }
}
