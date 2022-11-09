using App.Upgrades;
using App.World.Entity.Player.PlayerComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUpgrade : ScriptableObject, IUpgrade
{
    
    public abstract void Disable(Player upgradable);


    public abstract void Enable(Player upgradable);


    public abstract void UpdateUpgrade(Player upgradable);
    
}
