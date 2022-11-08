﻿using App.World.Entity.Player.PlayerComponents;
using UnityEngine;

namespace App.Upgrades.ConcreteUpgrades
{
    [CreateAssetMenu(fileName = "HPRegenRateUp", menuName = "Scriptable Objects/Upgrades/HPRegenRateUpgrade")]
    public class HPRegenRateUpgrade : BaseUpgrade
    {
        #region Serialized Fields
        [Min(0.0f)]
        [SerializeField] private float hpRegenRateAddent;
        #endregion

        #region Non-serialized Fields
        private float timeCounter  = 0.0f;
        private const float period = 1.0f;
        private bool isEnabled     = false;
        #endregion

        public override void Enable(Player upgradable)
        {
            if (isEnabled) return;
            isEnabled = true;
        }

        public override void UpdateUpgrade(Player upgradable) 
        {
            if (!isEnabled) return;

            var health = upgradable.Health;
            if (timeCounter > period)
            {
                health.Heal(hpRegenRateAddent);
                timeCounter = 0f;
            }
            else
            {
                timeCounter += Time.deltaTime;
            }
        }

        public override void Disable(Player upgradable)
        {
            if (!isEnabled) return;
            isEnabled = false;
        }
    }
}