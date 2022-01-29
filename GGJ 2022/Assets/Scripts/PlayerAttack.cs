using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PoolHandler<Bullet>
{
    public Bullet bulletPf;
    public float damage;

    public Transform aimmer;

    Watch fireCoolDown;

    protected override GameObject prefab => bulletPf.gameObject;

    private void Start()
    {
        fireCoolDown = new Watch(1, true);
    }

    private void Update()
    {
        if (fireCoolDown.TimeOut && Input.GetButton("Fire1"))
        {
            Bullet obj = Spawn();
            //obj.transform.position = transform.position;
            //obj.transform.rotation = aimmer.rotation;
            fireCoolDown.Reset();
        }
    }

    protected override Bullet Spawn()
    {
        Bullet obj = pool.Count > 0 ? pool.Dequeue() : Instantiate(prefab).GetComponent<Bullet>();
        obj.Setup(damage);
        obj.transform.position = transform.position;
        obj.transform.rotation = aimmer.rotation;
        obj.OnGet();
        obj.gameObject.SetActive(true);
        return obj;
    }
}
