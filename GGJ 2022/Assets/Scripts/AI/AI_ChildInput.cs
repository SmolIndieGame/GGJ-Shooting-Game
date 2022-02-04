using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_ChildInput : MonoBehaviour, IChildInput
{
    public float MovementX { get; private set; }
    public float MovementY { get; private set; }
    public bool Combine { get; private set; }
    float curAngle;
    bool @switch;

    public Camera cam;
    public EnemySpawner enemySpawner;

    Watch actionClock = new Watch(0.1f, true, Watch.StartingState.Zero);

    private void Update()
    {
        if (actionClock.TimeOut)
        {
            MovementX = 0;
            MovementY = 0;
            Combine = false;
            PerformAction();
            actionClock.Reset();
        }
    }

    private void PerformAction()
    {
        (Enemy obj, float dis) enemy1 = (null, float.MaxValue), enemy2 = (null, float.MaxValue);
        foreach (var enemy in enemySpawner.spawnedEnemies)
        {
            float dis = Vector2.Distance(enemy.transform.position, transform.position);
            if (enemy1.obj == null || enemy1.dis > dis)
            {
                enemy2 = enemy1;
                enemy1 = (enemy, dis);
            }
        }

        Vector2 move = Vector2.zero;
        if (enemy1.obj != null && enemy1.dis < 4)
        {
            move = transform.position - enemy1.obj.transform.position;
        }
        if (enemy2.obj != null && enemy2.dis < 4)
        {
            move += (Vector2)(transform.position - enemy2.obj.transform.position);
        }
        move.Normalize();

        Bounds screenBound = new Bounds();
        screenBound.SetMinMax(cam.ViewportToWorldPoint(Vector3.zero), cam.ViewportToWorldPoint(Vector3.one));
        screenBound.Expand(new Vector3(-2, -2, 0));

        if (move != Vector2.zero && screenBound.Contains(transform.position))
        {
            MovementX = move.x;
            MovementY = move.y;
            Debug.Log("Scare");
            return;
        }

        //screenBound.Expand(new Vector3(1, 1, 0));
        if (!@switch && !screenBound.Contains(transform.position))
        {
            @switch = true;
            MovementX = curAngle == 0 || curAngle == 2 ? 1 - curAngle : 0;
            MovementY = curAngle == 1 || curAngle == 3 ? 2 - curAngle : 0;
            Debug.Log("Turn");
            return;
        }

        if (@switch)
        {
            curAngle = (curAngle + 1) % 4;
            @switch = false;
        }
        MovementX = curAngle == 0 || curAngle == 2 ? curAngle - 1 : 0;
        MovementY = curAngle == 1 || curAngle == 3 ? curAngle - 2 : 0;
    }
}
