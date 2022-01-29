using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public static DifficultyController I { get; private set; }
    public event System.Action onDataUpdate;

    public Timing timing;
    public int startingDifficulty;
    [Header("Data")]
    public DifficultyData[] difficulties;
    [Header("Current")]
    DifficultyData usingDifficulty;
    public int difficultyLevel { get; private set; }
    public float enemySpawningInterval { get; private set; }
    public float enemyHealth { get; private set; }
    public float enemySpeed { get; private set; }

    private void Awake()
    {
        I = this;
        usingDifficulty = difficulties[startingDifficulty];
        UpdateData();
    }

    private void Update()
    {
        int temp = difficultyLevel;
        difficultyLevel = (int)usingDifficulty.difficultyLevel.Evaluate(timing.elapsedSeconds);
        if (temp != difficultyLevel)
            UpdateData();
    }

    void UpdateData()
    {
        enemySpawningInterval = usingDifficulty.enemySpawningInterval.Evaluate(difficultyLevel);
        enemyHealth = usingDifficulty.enemyHealth.Evaluate(difficultyLevel);
        enemySpeed = usingDifficulty.enemySpeed.Evaluate(difficultyLevel);

        var temp = onDataUpdate;
        temp?.Invoke();
    }
}
