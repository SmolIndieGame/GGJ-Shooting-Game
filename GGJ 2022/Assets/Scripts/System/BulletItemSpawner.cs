using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItemSpawner : PoolHandler<BulletItem>
{
    [SerializeField] BulletItem bulletPf;
    [SerializeField] Camera cam;
    [SerializeField] float interval;

    Watch watch;

    protected override GameObject prefab => bulletPf.gameObject;

    private void Start()
    {
        watch = new Watch(interval, true);
    }

    private void Update()
    {
        if (watch.TimeOut)
        {
            Vector2 pos = new Vector2();

            pos.x = Random.value;
            pos.y = Random.value;

            pos = cam.ViewportToWorldPoint(pos);

            BulletItem bullet = Spawn();
            bullet.transform.position = pos;

            watch.Reset();
        }
    }
}
