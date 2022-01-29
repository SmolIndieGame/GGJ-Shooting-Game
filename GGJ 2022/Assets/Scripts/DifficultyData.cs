using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Difficulty", menuName = "DifficultyData")]
public class DifficultyData : ScriptableObject
{
    [Tooltip("This is the difficulty level with respect to time.\n\nDifficulty level ranges from 1-20")]
    public AnimationCurve difficultyLevel;
    [Tooltip("How fast enemies spawn with respect to difficulty level. (smaller value = spawn faster)\n\nDifficulty level ranges from 1-20")]
    public AnimationCurve enemySpawningInterval;
    [Tooltip("enemy health with respect to difficulty level.\n\nDifficulty level ranges from 1-20")]
    public AnimationCurve enemyHealth;
    [Tooltip("enemy speed with respect to difficulty level.\n\nDifficulty level ranges from 1-20")]
    public AnimationCurve enemySpeed;
}
