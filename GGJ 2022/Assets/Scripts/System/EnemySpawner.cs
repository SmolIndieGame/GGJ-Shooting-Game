using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PoolHandler<Enemy>
{
    [SerializeField] Enemy enemyPf;
    [SerializeField] Camera cam;

    Watch watch;

    protected override GameObject prefab => enemyPf.gameObject;

    private void Start()
    {
        DifficultyController.I.onDataUpdate += ChangeInterval;
        watch = new Watch(DifficultyController.I.enemySpawningInterval, true);
    }

    void ChangeInterval() => watch.SetNewDuration(DifficultyController.I.enemySpawningInterval);

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

            Enemy enemy = Spawn();
            enemy.transform.position = pos;

            watch.Reset();
        }
    }
}
