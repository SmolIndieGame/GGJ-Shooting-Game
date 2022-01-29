using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHandle : MonoBehaviour
{
    public UpdateBulletAmount bulletUI;

    [Header("Data")]
    public int MagCapacity;
    public float coolDown;

    [Header("Current")]
    int bulletInMag;
    int bulletInBag;
    bool reloading;

    Watch reloadCoolDown;

    private void Start()
    {
        reloadCoolDown = new Watch(coolDown, true, Watch.StartingState.Full);
        bulletInBag = 999;
        bulletInMag = MagCapacity;

        bulletUI.UpdateUI(bulletInMag, bulletInBag);
    }

    public bool UseBullet()
    {
        if (bulletInMag > 0)
        {
            bulletInMag--;
            bulletUI.UpdateUI(bulletInMag, bulletInBag);
            return true;
        }

        if (!reloading)
            Reload();
        return false;
    }

    public void Reload()
    {
        reloadCoolDown.Reset();
        reloading = true;
    }

    private void Update()
    {
        if (reloading && reloadCoolDown.TimeOut)
        {
            reloading = false;
            bulletInBag -= MagCapacity - bulletInMag;
            bulletInMag = MagCapacity;

            bulletUI.UpdateUI(bulletInMag, bulletInBag);
        }
    }
}
