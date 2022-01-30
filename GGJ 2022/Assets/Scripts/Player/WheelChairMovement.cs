using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{
    [Header("Force")]
    public float acceleration;
    public float maxVelocity;

    [Header("WheelChairMovement")]
    public float rotateSpeed;
    public Vector2 childOffset;
    public GameObject child;
    public Rigidbody2D rb;

    float rotate;

    [Header("Data")]
    public float stasisTime;
    [Header("Current")]
    public Watch stasisTimer;

    private void Awake()
    {
        stasisTimer = new Watch(stasisTime, true, Watch.StartingState.Full);
    }

    void Update()
    {
        rotate = Input.GetAxis("Horizontal") * -1;

        transform.Rotate(0, 0, rotate * rotateSpeed);
        child.transform.rotation = transform.rotation;

        if (stasisTimer.TimeOut && Input.GetKeyDown(KeyCode.Joystick1Button2))
            PushForward();
    }

    private void OnEnable()
    {
        rb.drag = 6;
    }

    private void OnDisable()
    {
        if (stasisTimer.TimeOut)
            rb.drag = 0.7f;
    }

    public void Recoil(Vector2 direction)
    {
        rb.drag = 6;
        stasisTimer.Reset();
        rb.AddForce(direction * 700);
    }

    void LateUpdate()
    {
        child.transform.position = (Vector2)transform.TransformPoint(childOffset);
    }

    void PushForward()
    {
        Vector2 force = transform.up * acceleration;
        rb.AddForce(force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
