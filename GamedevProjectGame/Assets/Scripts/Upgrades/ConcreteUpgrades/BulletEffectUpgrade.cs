using App.World.Entity.Player.PlayerComponents;
using UnityEngine;
using App.Effects;

namespace App.Upgrades.ConcreteUpgrades
{
    [CreateAssetMenu(fileName = "BulletEffectUpgrade", menuName = "Scriptable Objects/Upgrades/BulletEffectUpgrade")]
    public class BulletEffectUpgrade : BaseUpgrade
    {
        #region Serialized Fields
        [SerializeField] private BaseStatusEffect effect;
        #endregion

        #region Overriden Methods
        protected override void Upgrade(Player upgradable)
        {
            upgradable.Weapon.BulletEffect = effect;
        }

        protected override void Degrade(Player upgradable)
        {
            upgradable.Weapon.BulletEffect = null;
        }

        protected override void UpdateIfEnabled(Player upgradable) {}

        #endregion
    }
}
