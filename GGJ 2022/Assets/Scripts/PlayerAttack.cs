using UnityEngine;

public class PlayerAttack : PoolHandler<Bullet>
{
    public Bullet bulletPf;
    public Transform aimmer;

    [Header("Data")]
    public float damage;
    public float inaccuracy;
    public float coolDown;

    Watch fireCoolDown;

    protected override GameObject prefab => bulletPf.gameObject;

    private void Start()
    {
        fireCoolDown = new Watch(coolDown, true, Watch.StartingState.Full);
    }

    private void Update()
    {
        if (fireCoolDown.TimeOut && Input.GetButton("Fire1"))
        {
            Bullet obj = Spawn();
            float angle = aimmer.eulerAngles.z + Random.Range(-inaccuracy, inaccuracy);
            obj.Setup(damage, transform.position, (float)angle);
            fireCoolDown.Reset();
        }
    }
}
