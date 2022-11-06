using App.World.Entity.Player.Weapons;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingGun : Weapon
{
    public void Shoot(ShootEvent ev)
    {
        Shoot();
    }
    public void Shoot()
    {
        if (timeFromCoolDown > coolDown)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bullet.GetComponent<Bullet>().Speed;
            timeFromCoolDown = 0.0f;
        }
    }
}
