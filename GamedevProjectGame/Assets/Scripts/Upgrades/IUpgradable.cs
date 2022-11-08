﻿namespace App.Upgrades
{
    public interface IUpgradable
    {
        void EnableUpgrade(IUpgrade upgrade)  => upgrade.Enable(this);
        void UpdateUpgrade(IUpgrade upgrade)  => upgrade.Update(this);
        void DisableUpgrade(IUpgrade upgrade) => upgrade.Disable(this);
    }
}