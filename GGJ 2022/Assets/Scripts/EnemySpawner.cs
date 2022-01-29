using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PoolHandler<EnemyMovement>
{
    [SerializeField] EnemyMovement enemyPf;
    [SerializeField] Camera cam;
    [SerializeField] float interval;

    Watch watch;

    protected override GameObject prefab => enemyPf.gameObject;

    private void Start()
    {
        watch = new Watch(interval, true);
    }

    private void Update()
    {
        if (watch.TimeOut)
        {
            Vector2 pos = new Vector2();

            int state = Random.Range(0, 4);
            if (state < 2)
            {
                pos.x = Random.value;
                pos.y = state;
            }
            else
            {
                pos.y = Random.value;
                pos.x = state - 2;
            }

            pos = cam.ViewportToWorldPoint(pos);

            EnemyMovement enemy = Spawn();
            enemy.transform.position = pos;

            watch.Reset();
        }
    }
}
