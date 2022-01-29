using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBulletAmount : MonoBehaviour
{
    [SerializeField] TMP_Text bullet;

    public void UpdateUI(int cur, int max)
    {
        bullet.text = $"{cur}/{max}";
    }
}
