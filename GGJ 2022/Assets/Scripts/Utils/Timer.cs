using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject gui;

    // Update is called once per frame
    void Update()
    {
        gui.GetComponent<TMP_Text>().text = ((int)Time.timeSinceLevelLoad).ToString();
    }
}
