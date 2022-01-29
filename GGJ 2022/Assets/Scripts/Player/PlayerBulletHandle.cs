using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHandle : MonoBehaviour
{
    public UpdateBulletAmount bulletUI;

    [Header("Data")]
    public int bulletItemAmount;
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
        bulletInBag = 30;
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

        if (!reloading && bulletInBag > 0)
            Reload();
        return false;
    }

    public void Reload()
    {
        reloadCoolDown.Reset();
        reloading = true;
    }

    public void AddBullet()
    {
        bulletInBag += bulletItemAmount;
    }

    private void Update()
    {
        if (reloading && reloadCoolDown.TimeOut)
        {
            reloading = false;
            int needBullet = MagCapacity + bulletInMag;
            if (bulletInBag <= needBullet)
                bulletInMag += bulletInBag;
            else
                bulletInMag = MagCapacity;
            bulletInBag = Mathf.Max(0, bulletInBag - needBullet);

            bulletUI.UpdateUI(bulletInMag, bulletInBag);
        }
    }
}
