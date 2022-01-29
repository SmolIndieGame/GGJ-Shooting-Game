using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIHandle : MonoBehaviour
{
    public TMP_Text ingameScore;
    public TMP_Text endScore;

    public void GameOver()
    {
        gameObject.SetActive(true);
        endScore.text = ingameScore.text;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Test");
    }
}
