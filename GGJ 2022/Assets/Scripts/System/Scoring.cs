using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public static Scoring I { get; private set; }

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

    private void Awake()
    {
        I = this;
    }

    void Update()
    {
        timeScore = timer.elapsedSeconds * timeScoreFactor;
        gui.text = (enemyScore + (int)timeScore).ToString();
    }
}
