using UnityEngine;

public class PlayerAttack : PoolHandler<Bullet>
{
    PlayerBulletHandle bulletHandle;

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
        bulletHandle = GetComponent<PlayerBulletHandle>();
        fireCoolDown = new Watch(coolDown, true, Watch.StartingState.Full);
    }

    private void Update()
    {
        if (fireCoolDown.TimeOut && Input.GetButtonDown("Fire1") && bulletHandle.UseBullet())
        {
            Bullet obj = Spawn();
            float angle = aimmer.eulerAngles.z + Random.Range(-inaccuracy, inaccuracy);
            obj.Setup(damage, transform.position, (float)angle);

            fireCoolDown.Reset();
        }
    }
}
