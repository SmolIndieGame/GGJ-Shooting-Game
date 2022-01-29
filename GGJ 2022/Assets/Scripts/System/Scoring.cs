using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public Timing timer;
    public TMP_Text gui;

    [Header("Data")]
    public int enemyKillBonus = 10;
    public float timeScoreFactor = 0.5f;

    [Header("Current")]
    int enemyScore;
    float timeScore;

    public void Earn()
    {
        this.enemyScore += enemyKillBonus;
    }

    void Update()
    {
        timeScore = timer.elapsedSeconds * timeScoreFactor;
        gui.text = (enemyScore + (int)timeScore).ToString();
    }
}
