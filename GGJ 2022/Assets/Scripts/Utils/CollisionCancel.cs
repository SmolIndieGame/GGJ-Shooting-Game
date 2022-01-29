using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCancel : MonoBehaviour
{
    public Collider2D collider1;
    public Collider2D collider2;

    private void Start()
    {
        Physics2D.IgnoreCollision(collider1, collider2);
    }
}
