using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParticleType
{
    Blood,
    Damage,
    Die
}

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool I { get; private set; }

    public BloodParticle bloodParticlePf;
    public DamageParticle damageParticlePf;
    public DieParticle DieParticlePf;

    PoolHandler<BloodParticle> bloodParticle;
    PoolHandler<DamageParticle> damageParticle;
    PoolHandler<DieParticle> dieParticle;

    private void Awake()
    {
        I = this;

        bloodParticle = new PoolHandler<BloodParticle>(bloodParticlePf.gameObject);
        damageParticle = new PoolHandler<DamageParticle>(damageParticlePf.gameObject);
        dieParticle = new PoolHandler<DieParticle>(DieParticlePf.gameObject);
    }

    public void SpawnParticle(ParticleType particleType, Vector3 position, Vector3 direction, float lastTime)
    {
        GameObject pObj = particleType switch
        {
            ParticleType.Blood => bloodParticle.Spawn().Duration(lastTime),
            ParticleType.Damage => damageParticle.Spawn().Duration(lastTime),
            ParticleType.Die => dieParticle.Spawn().Duration(lastTime),
            _ => null,
        };
        pObj.transform.position = position;
        pObj.transform.up = direction;
    }
}
