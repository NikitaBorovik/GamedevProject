using App.World.Entity.Player.PlayerComponents;
using UnityEngine;

namespace App.Upgrades
{
    public interface IUpgrade
    {
        void Enable(IUpgradable upgradable)
        {
            Debug.LogWarning($"There's no method-visitor for: { upgradable.GetType().Name }. " +
                $"Add one or check the correctness of {GetType().Name}.");
        }
        void Update(IUpgradable upgradable)
        {
            Debug.LogWarning($"There's no method-visitor for: { upgradable.GetType().Name }. " +
                $"Add one or check the correctness of {GetType().Name}.");
        }

        void Disable(IUpgradable upgradable)
        {
            Debug.LogWarning($"There's no method-visitor for: { upgradable.GetType().Name }. " +
                $"Add one or check the correctness of {GetType().Name}.");
        }

        void Enable(Player upgradable);
        void Update(Player upgradable);
        void Disable(Player upgradable);

        //void Enable(Enemy); ...
    }
}
