using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour, IObjectPooled<BloodParticle>
{
    public PoolHandler<BloodParticle> poolHandler { get; set; }

    public GameObject Duration(float time)
    {
        Invoke(nameof(Return), time);
        return gameObject;
    }

    void Return() => poolHandler.Return(this);

    public void OnGet() { }
    public void OnReturn() { }
}
