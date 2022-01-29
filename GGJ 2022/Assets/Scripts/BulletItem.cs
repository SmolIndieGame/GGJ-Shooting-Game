using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour, IObjectPooled<BulletItem>
{
    public PoolHandler<BulletItem> poolHandler { get; set; }

    public void Return() => poolHandler.Return(this);

    public void OnGet() { }
    public void OnReturn() { }
}
