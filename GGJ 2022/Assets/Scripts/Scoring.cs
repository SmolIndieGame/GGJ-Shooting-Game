using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int score = 0;
    public int enemyScore = 100;

    // Start is called before the first frame update
    public void Earn(){
        this.score += enemyScore;
    }
}
