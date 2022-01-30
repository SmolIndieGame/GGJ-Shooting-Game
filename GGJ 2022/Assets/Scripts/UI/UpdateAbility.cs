using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateAbility : MonoBehaviour
{
    public TMP_Text cooldown;
    public Color offColor;
    public Color onColor;
    public float maxCD;

    double lastFire;

    private void Update()
    {
        double t = Time.timeAsDouble - lastFire;
        cooldown.text = $"{(int)t}/{(int)maxCD}";
        cooldown.color = t >= maxCD ? onColor : offColor;
    }

    public void UpdateCoolDown(double lastFire)
    {
        this.lastFire = lastFire;
    }
}
