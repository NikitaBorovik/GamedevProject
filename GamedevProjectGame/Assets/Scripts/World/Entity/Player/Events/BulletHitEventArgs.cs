using UnityEngine;
using App.Effects;

namespace App.World.Entity.Player.Events
{
    public class BulletHitEventArgs
    {
        public GameObject target;
        public BaseStatusEffect effect;
    }
}
