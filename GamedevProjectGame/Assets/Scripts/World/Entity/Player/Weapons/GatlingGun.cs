using App.World.Entity.Player.Weapons;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace App.World.Entity.Player.Weapons
{
    public class GatlingGun : Weapon
    {
        public override void Shoot()
        {
            if (timeFromCoolDown > coolDown)
            {
                Bullet bulletScript = bulletPrefab.GetComponent<Bullet>();
                if (bulletScript == null)
                {
                    Debug.Log("Trying to shoot bullet that doesn't contain Bullet script");
                    return;
                }
                GameObject bullet = objectPool.GetObjectFromPool(bulletScript.PoolObjectType, bulletPrefab, shootPosition.position).GetGameObject();
                bullet.transform.rotation = shootPosition.rotation;
                bullet.transform.position = shootPosition.position;
                //Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
                bullet.GetComponent<Bullet>().Init(damage);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletFlySpeed;
                timeFromCoolDown = 0.0f;
            }
        }
    }
}

