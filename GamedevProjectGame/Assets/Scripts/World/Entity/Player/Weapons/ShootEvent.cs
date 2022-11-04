using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public class ShootEvent : MonoBehaviour
    {
        public event Action<ShootEvent> OnShoot;

        public void CallShootEvent()
        {
            OnShoot?.Invoke(this);
        }
    }
}