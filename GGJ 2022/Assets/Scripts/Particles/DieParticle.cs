using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieParticle : MonoBehaviour, IObjectPooled<DieParticle>
{
    public PoolHandler<DieParticle> poolHandler { get; set; }

    public GameObject Duration(float time)
    {
        Invoke(nameof(Return), time);
        return gameObject;
    }

    void Return() => poolHandler.Return(this);

    public void OnGet() { }
    public void OnReturn() { }
}
