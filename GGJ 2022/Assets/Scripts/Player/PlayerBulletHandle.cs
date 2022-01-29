using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHandle : MonoBehaviour
{
    public UpdateBulletAmount bulletUI;

    [Header("Data")]
    public AudioClip noBulletSound;
    public AudioClip reloadSound;
    public int bulletItemAmount;
    public int startingBullet = 24;
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
        bulletInBag = startingBullet;
        bulletInMag = MagCapacity;

        bulletUI.UpdateUI(bulletInMag, bulletInBag);
    }

    public bool UseBullet()
    {
        if (reloading)
            return false;

        if (bulletInMag > 0)
        {
            bulletInMag--;
            bulletUI.UpdateUI(bulletInMag, bulletInBag);
            return true;
        }

        if (!reloading)
            if (bulletInBag > 0)
                Reload();
            else
                Sounds.I.Play(noBulletSound);
        return false;
    }

    public void Reload()
    {
        Sounds.I.Play(reloadSound);
        reloadCoolDown.Reset();
        reloading = true;
    }

    public void AddBullet()
    {
        bulletInBag += bulletItemAmount;
        bulletUI.UpdateUI(bulletInMag, bulletInBag);
    }

    private void Update()
    {
        if (!reloading && bulletInBag > 0 && Input.GetButtonDown("Fire2"))
            Reload();

        if (reloading && reloadCoolDown.TimeOut)
        {
            reloading = false;
            int needBullet = MagCapacity - bulletInMag;
            if (bulletInBag <= needBullet)
                bulletInMag += bulletInBag;
            else
                bulletInMag = MagCapacity;
            bulletInBag = Mathf.Max(0, bulletInBag - needBullet);

            bulletUI.UpdateUI(bulletInMag, bulletInBag);
        }
    }
}
