using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public GameObject gui;
    public int score = 0;
    public int enemyScore = 100;

    // Start is called before the first frame update
    public void Earn()
    {
        this.score += enemyScore;
        UpdateGUI();
    }

    void UpdateGUI()
    {
        gui.GetComponent<TMP_Text>().text = score.ToString();
    }
}
