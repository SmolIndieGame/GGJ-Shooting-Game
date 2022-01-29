using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementConstaint : MonoBehaviour
{
    const float PLAYER_SIZE = 1;

    public Camera cam;
    Bounds screenBound;

    private void Start()
    {
        screenBound = new Bounds();
        screenBound.SetMinMax(cam.ViewportToWorldPoint(Vector3.zero), cam.ViewportToWorldPoint(Vector3.one));
        screenBound.Expand(-PLAYER_SIZE);
    }

    private void LateUpdate()
    {
        transform.position = screenBound.ClosestPoint(transform.position);
    }
}
