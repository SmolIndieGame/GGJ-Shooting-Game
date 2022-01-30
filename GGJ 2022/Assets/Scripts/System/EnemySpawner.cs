using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPf;
    [SerializeField] Camera cam;

    PoolHandler<Enemy> poolHandler;
    Watch watch;

    private void Start()
    {
        DifficultyController.I.onDataUpdate += ChangeInterval;
        poolHandler = new PoolHandler<Enemy>(enemyPf.gameObject);
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

            Enemy enemy = poolHandler.Spawn();
            enemy.transform.position = pos;

            watch.Reset();
        }
    }
}
