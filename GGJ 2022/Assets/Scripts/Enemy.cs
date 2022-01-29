using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPooled<Enemy>
{
    EnemyHealth health;

    [Header("Data")]
    public float stasisTime;
    [Header("Current")]
    public Watch stasisTimer;

    public PoolHandler<Enemy> poolHandler { get; set; }

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
        stasisTimer = new Watch(stasisTime, true, Watch.StartingState.Full);
    }
    public void OnGet()
    {
        health.Init();
    }
    public void OnReturn() { }

    public void Return() => poolHandler.Return(this);
}
