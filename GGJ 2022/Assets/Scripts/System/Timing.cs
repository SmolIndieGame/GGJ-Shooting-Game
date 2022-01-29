using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timing : MonoBehaviour
{
    public TMP_Text gui;

    [Header("Current")]
    public int elapsedSeconds;

    void Update()
    {
        elapsedSeconds = (int)Time.timeSinceLevelLoad;
        int min = elapsedSeconds / 60;
        int sec = elapsedSeconds % 60;

        gui.text = $"{min:00}:{sec:00}";
    }
}
