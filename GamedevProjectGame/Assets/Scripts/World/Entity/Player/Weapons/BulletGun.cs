using App.World.Entity.Player.Weapons;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace App.World.Entity.Player.Weapons
{
    public class BulletGun : Weapon
    {
        
        bool isShooting = false;
        public override void Shoot()
        {
            isShooting = true;
            if (timeFromCoolDown > coolDown)
            {
                Bullet bulletScript = bulletPrefab.GetComponent<Bullet>();
                if (bulletScript == null)
                {
                    Debug.Log("Trying to shoot bullet that doesn't contain Bullet script");
                    return;
                }
                for (int i = 0; i < bulletCount; i++)
                {
                    float spread = Random.Range(-bulletSpread, bulletSpread);
                    Quaternion rotation = Quaternion.Euler(ShootPosition.eulerAngles.x, ShootPosition.eulerAngles.y, ShootPosition.eulerAngles.z + spread);
                    GameObject bullet = objectPool.GetObjectFromPool(bulletScript.PoolObjectType, bulletPrefab, ShootPosition.position).GetGameObject();
                    // bullet.transform.rotation = shootPosition.rotation;
                    bullet.transform.rotation = rotation;
                    bullet.transform.position = ShootPosition.position;
                    //Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
                    bullet.GetComponent<Bullet>().Init(damage);
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletFlySpeed;
                }
                timeFromCoolDown = 0.0f;
            }
        }

        //new void Update()
        //{
        //    base.Update();
        //    if (isShooting)
        //    {
        //        var emission = GetComponentInChildren<ParticleSystem>().emission;
        //        emission.rateOverTime = 6000;
        //        isShooting = false;
        //    }
        //    else
        //    {
        //        var emission = GetComponentInChildren<ParticleSystem>().emission;
        //        emission.rateOverTime = 0;
        //    }
        //}
    }
}

