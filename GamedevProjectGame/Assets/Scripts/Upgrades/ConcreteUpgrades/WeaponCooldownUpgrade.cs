using App.World.Entity.Player.PlayerComponents;
using System;
using UnityEngine;

namespace App.Upgrades.ConcreteUpgrades
{
    [CreateAssetMenu(fileName = "WpnCooldownUp", menuName = "Scriptable Objects/Upgrades/WeaponCooldownUpgrade")]
    public class WeaponCooldownUpgrade : ScriptableObject, IUpgrade
    {
        [Range(0f, 1f)]
        [SerializeField] private float cooldownMultiplier;

        public void Enable(Player upgradable)
        {
            upgradable.Weapon.Cooldown *= cooldownMultiplier;
        }

        public void Update(Player upgradable) {}

        public void Disable(Player upgradable)
        {
            upgradable.Weapon.Cooldown /= cooldownMultiplier;
        }
    }
}
