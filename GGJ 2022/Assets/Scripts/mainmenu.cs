using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void Playgame(){
        SceneManager.LoadScene("Test");
    }

    public void Tutorial(){
        SceneManager.LoadScene("tutorial");
    }

    public void Endgame(){
        Application.Quit();
    }
}
