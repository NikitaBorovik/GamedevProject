using App.Upgrades;
using App.World.Entity.Player.PlayerComponents;
using UnityEngine;

public abstract class BaseUpgrade : ScriptableObject
{
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

    public abstract void Disable(Player upgradable);

    public abstract void UpdateUpgrade(Player upgradable);

    public abstract void Enable(Player upgradable);
}
