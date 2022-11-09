﻿using App.World.Entity.Player.PlayerComponents;
using System.Collections.Generic;
using UnityEngine;

namespace App.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        #region Fields
        [SerializeReference]
        private List<BaseUpgrade> upgrades;
        private IUpgradable upgradableEntity;
        #endregion

        #region MonoBehaviour Methods
        private void Awake()
        {
            upgrades = new List<BaseUpgrade>();
            upgradableEntity = GetComponent<IUpgradable>();
        }

        private void Update()
        {
            UpdateAll();
        }
        #endregion

        #region Custom Methods
        public void EnableAll() => upgrades.ForEach(u => upgradableEntity.EnableUpgrade(u));

        public void UpdateAll() => upgrades.ForEach(u => upgradableEntity.UpdateUpgrade(u));

        public void DisableAll() => upgrades.ForEach(u => upgradableEntity.DisableUpgrade(u));

        public void AddUpgrade(BaseUpgrade upgrade)
        {
            upgrades.Add(upgrade);
            //upgrade.Enable(upgradableEntity as Player);
            upgradableEntity.EnableUpgrade(upgrade);
        }
        #endregion
    }
}
