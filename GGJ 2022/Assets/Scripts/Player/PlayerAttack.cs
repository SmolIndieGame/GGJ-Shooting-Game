using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerBulletHandle bulletHandle;

    public Bullet bulletPf;
    public Bullet2 bullet2Pf;
    public Transform aimmer;

    [Header("Data")]
    public AudioClip fireSound;
    public Vector2 gunOffset;
    public float damage;
    public float abilityDamage;
    public float inaccuracy;
    public float coolDown;

    PoolHandler<Bullet> bulletPool;
    PoolHandler<Bullet2> spreadPool;
    Watch fireCoolDown;

    private void Start()
    {
        bulletHandle = GetComponent<PlayerBulletHandle>();

        bulletPool = new PoolHandler<Bullet>(bulletPf.gameObject);
        spreadPool = new PoolHandler<Bullet2>(bullet2Pf.gameObject);
        fireCoolDown = new Watch(coolDown, true, Watch.StartingState.Full);
    }

    private void Update()
    {
        if (fireCoolDown.TimeOut)
        {
            if (Input.GetButtonDown("Fire1") && bulletHandle.UseBullet())
            {
                Bullet obj = bulletPool.Spawn();
                float angle = aimmer.eulerAngles.z + Random.Range(-inaccuracy, inaccuracy);
                obj.Setup(damage, aimmer.TransformPoint(gunOffset), (float)angle);
                Sounds.I.Play(fireSound, 0.8f);

                fireCoolDown.Reset();
            }
            if (Input.GetButtonDown("Fire2") && bulletHandle.UseBullet(4))
            {
                Bullet2 obj = spreadPool.Spawn();
                float angle = aimmer.eulerAngles.z + Random.Range(-inaccuracy, inaccuracy);
                obj.Setup(abilityDamage, aimmer.TransformPoint(gunOffset), (float)angle);
                Sounds.I.Play(fireSound, 0.8f);
                GetComponent<Rigidbody2D>().AddForce(-aimmer.up * 1200);
                
                fireCoolDown.Reset();
            }
        }
    }
}
