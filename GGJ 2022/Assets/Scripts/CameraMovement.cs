using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    float power;
    float leftTime;
    float curPower;

    public void Shake(float power, float time)
    {
        if (curPower > power) return;

        this.power = power;
        leftTime = time;
    }

    private void Update()
    {
        if (leftTime <= 0)
        {
            cam.transform.position = Vector3.zero;
            return;
        }

        leftTime -= Time.deltaTime;

        curPower = Mathf.Lerp(0, power, leftTime);
        Vector2 pos = Random.insideUnitCircle * curPower;

        cam.transform.position = pos;
    }
}
