using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpBullet : MonoBehaviour
{
    public bool HaveBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HaveBullet && collision.CompareTag("BulletItem"))
        {
            collision.gameObject.GetComponent<BulletItem>().Return();
            HaveBullet = true;
        }
    }
}
