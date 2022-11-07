using App.World.Entity.Player.PlayerComponents;
using System;
using UnityEngine;

namespace App.Upgrades.ConcreteUpgrades
{
    [CreateAssetMenu(fileName = "HPRegenRateUp", menuName = "Scriptable Objects/Upgrades/HPRegenRateUpgrade")]
    public class HPRegenRateUpgrade : ScriptableObject, IUpgrade
    {
        [Min(0.0f)]
        [SerializeField] private float cooldownMultiplier;

        public void Enable(Player upgradable)
        {
            upgradable.Weapon.Cooldown *= cooldownMultiplier;
        }

        public void Update(Player upgradable) { }

        public void Disable(Player upgradable)
        {
            upgradable.Weapon.Cooldown /= cooldownMultiplier;
        }
    }
}
