using App.World.Entity.Player.PlayerComponents;
using System;
using UnityEngine;

namespace App.Upgrades.ConcreteUpgrades
{
    [CreateAssetMenu(fileName = "WpnCooldownUp", menuName = "Scriptable Objects/Upgrades/WeaponCooldownUpgrade")]
    public class WeaponCooldownUpgrade : BaseUpgrade
    {
        [Range(0f, 1f)]
        [SerializeField] private float cooldownMultiplier;
        private bool isEnabled;

        public override void Enable(Player upgradable)
        {
            if (isEnabled) return;
            isEnabled = true;
            upgradable.Weapon.Cooldown *= cooldownMultiplier;
            Debug.Log(upgradable.Weapon.Cooldown);
        }

        public override void UpdateUpgrade(Player upgradable) {}

        public override void Disable(Player upgradable)
        {
            if (!isEnabled) return;
            isEnabled = false;
            upgradable.Weapon.Cooldown /= cooldownMultiplier;
        }
    }
}
