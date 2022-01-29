using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController I { get; private set; }

    private void Awake()
    {
        I = this;
    }
}
