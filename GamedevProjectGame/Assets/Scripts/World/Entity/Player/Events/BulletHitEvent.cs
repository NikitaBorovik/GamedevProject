using System;
using UnityEngine;
using App.Effects;

namespace App.World.Entity.Player.Events
{
    public class BulletHitEvent : MonoBehaviour
    {
        public event Action<BulletHitEvent, BulletHitEventArgs> OnHit;

        public void CallBulletHitEvent(GameObject target, BaseStatusEffect effect)
        {
            BulletHitEventArgs args = new () { target = target, effect = effect };
            OnHit?.Invoke(this, args);
        }
    }
}
