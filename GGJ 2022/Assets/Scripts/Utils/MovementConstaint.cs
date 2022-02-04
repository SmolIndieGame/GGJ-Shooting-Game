using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementConstaint : MonoBehaviour
{
    const float PLAYER_SIZE = 1;

    public Camera cam;
    public new Rigidbody2D rigidbody;
    Bounds screenBound;

    private void Start()
    {
        screenBound = new Bounds();
        screenBound.SetMinMax(cam.ViewportToWorldPoint(Vector3.zero), cam.ViewportToWorldPoint(Vector3.one));
        screenBound.Expand(-PLAYER_SIZE);
    }

    private void LateUpdate()
    {
        rigidbody.position = (Vector2)screenBound.ClosestPoint(transform.position);
    }
}
