using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChildInput
{
    float MovementX { get; }
    float MovementY { get; }
    bool Combine { get; }
}

public class ChildInput : MonoBehaviour, IChildInput
{
    public float MovementX => Input.GetAxisRaw("Horizontal");
    public float MovementY => Input.GetAxisRaw("Vertical");
    public bool Combine => Input.GetButtonDown("Combine");
}