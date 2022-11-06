using App.World.Entity.Player.Weapons;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatlingGun : Weapon
{
    public override void Shoot()
    {
        if (timeFromCoolDown > coolDown)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
            bullet.GetComponent<Bullet>().Init(damage);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletFlySpeed;
            timeFromCoolDown = 0.0f;
        }
    }
}
