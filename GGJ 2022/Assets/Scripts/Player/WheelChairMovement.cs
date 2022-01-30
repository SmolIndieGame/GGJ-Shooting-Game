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
    bool pushing;
    bool pulling;

    private void Awake()
    {
        stasisTimer = new Watch(stasisTime, true, Watch.StartingState.Full);
    }

    void Update()
    {
        rotate = Input.GetAxis("Horizontal") * -1;

        transform.Rotate(0, 0, rotate * rotateSpeed);
        child.transform.rotation = transform.rotation;

        pushing = Input.GetButton("Push");
        pulling = Input.GetButton("Pull");

        //rb.velocity = Vector2.zero;// Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void OnEnable()
    {
        rb.drag = 6f;
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

    private void FixedUpdate()
    {
        if (!stasisTimer.TimeOut) return;

        if (pushing) PushForward();
        if (pulling) PullBackward();
        //rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        child.transform.position = (Vector2)transform.TransformPoint(childOffset);
    }

    void PushForward()
    {
        Vector2 force = transform.up * acceleration;
        rb.AddForce(force);
    }

    void PullBackward()
    {
        Vector2 force = -transform.up * acceleration;
        rb.AddForce(force);
    }
}
