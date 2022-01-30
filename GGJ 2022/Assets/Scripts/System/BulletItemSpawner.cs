using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItemSpawner : MonoBehaviour
{
    [SerializeField] BulletItem bulletPf;
    [SerializeField] Camera cam;
    [SerializeField] float interval;

    PoolHandler<BulletItem> poolHandler;
    Watch watch;

    private void Start()
    {
        poolHandler = new PoolHandler<BulletItem>(bulletPf.gameObject);
        watch = new Watch(interval, true);
    }

    private void Update()
    {
        if (watch.TimeOut)
        {
            Vector2 pos = new Vector2
            {
                x = Random.Range(0.05f, 0.95f),
                y = Random.Range(0.05f, 0.95f)
            };

            pos = cam.ViewportToWorldPoint(pos);

            BulletItem bullet = poolHandler.Spawn();
            bullet.transform.position = pos;

            watch.Reset();
        }
    }
}
