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
        private bool isEnabled;

        public void Enable(Player upgradable)
        {
            if (isEnabled) return;
            isEnabled = true;
            upgradable.Weapon.Cooldown *= cooldownMultiplier;
        }

        public void UpdateUpgrade(Player upgradable) {}

        public void Disable(Player upgradable)
        {
            if (!isEnabled) return;
            isEnabled = false;
            upgradable.Weapon.Cooldown /= cooldownMultiplier;
        }
    }
}
