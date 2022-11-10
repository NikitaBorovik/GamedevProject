using App.World.Entity.Player.PlayerComponents;
using UnityEngine;

namespace App.Upgrades
{
    public abstract class BaseUpgrade : ScriptableObject
    {
        #region Properties
        public bool IsEnabled { get; private set; } = false;
        #endregion

        #region Default Visitor Methods
        public void Enable(IUpgradable upgradable)
        {
            Debug.LogWarning($"There's no method-visitor taking: { upgradable.GetType().Name } param. " +
                $"Add one or check the correctness of {GetType().Name}.");
        }
        public void UpdateUpgrade(IUpgradable upgradable)
        {
            Debug.LogWarning($"There's no method-visitor taking: { upgradable.GetType().Name } param. " +
                $"Add one or check the correctness of {GetType().Name}.");
        }

        public void Disable(IUpgradable upgradable)
        {
            Debug.LogWarning($"There's no method-visitor taking: { upgradable.GetType().Name } param. " +
                $"Add one or check the correctness of {GetType().Name}.");
        }
        #endregion

        #region Template Methods
        public void Enable(Player upgradable)
        {
            if (IsEnabled) return;
            IsEnabled = true;
            Upgrade(upgradable);
        }
        public void UpdateUpgrade(Player upgradable)
        {
            if (!IsEnabled) return;
            UpdateIfEnabled(upgradable);
        }

        public void Disable(Player upgradable)
        {
            if (!IsEnabled) return;
            IsEnabled = false;
            Degrade(upgradable);
        }
        #endregion

        #region Abstract Methods
        protected abstract void Upgrade(Player upgradable);

        protected abstract void UpdateIfEnabled(Player upgradable);

        protected abstract void Degrade(Player upgradable);
        #endregion
    }
}