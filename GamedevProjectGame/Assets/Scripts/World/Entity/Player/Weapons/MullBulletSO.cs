using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.World.Entity.Player.Weapons
 {   
    [CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Scriptable Objects/Weapons/ Mull Bullet Weapon Data")]
    public class MullBulletSO : SingleBulletGun
    {
        public int bulletCount;
    }
}
