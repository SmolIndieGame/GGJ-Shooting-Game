using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPooled<Enemy>
{
    EnemyHealth health;
    EnemyMovement movement;

    [Header("Data")]
    public GameObject deadEffPf;
    public float stasisTime;
    [Header("Current")]
    public Watch stasisTimer;

    public PoolHandler<Enemy> poolHandler { get; set; }

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
        movement = GetComponent<EnemyMovement>();
        stasisTimer = new Watch(stasisTime, true, Watch.StartingState.Full);
    }
    public void OnGet()
    {
        health.Init();
        movement.Init();
    }
    public void OnReturn() { }

    public void Return()
    {
        poolHandler.Return(this);
        Instantiate(deadEffPf, transform.position, transform.rotation);
    }
}
