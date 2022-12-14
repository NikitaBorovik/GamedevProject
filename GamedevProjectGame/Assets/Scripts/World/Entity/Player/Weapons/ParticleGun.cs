using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.World.Entity.Player.Weapons
{
    public class ParticleGun : Weapon
    {
        bool isShooting = false;
        new void Update()
        {
            base.Update();
            if (isShooting)
            {
                var emission = GetComponentInChildren<ParticleSystem>().emission;
                emission.rateOverTime = 6000;
                isShooting = false;
            }
            else
            {
                var emission = GetComponentInChildren<ParticleSystem>().emission;
                GetComponentInChildren<PolygonCollider2D>().enabled = false;
                emission.rateOverTime = 0;
            }
        }
        public override void Shoot()
        {
            isShooting = true;
            GetComponentInChildren<PolygonCollider2D>().enabled = true;
        }
    }
}
