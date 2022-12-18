using System;
using UnityEngine;

namespace App.World.Entity.Player.Events
{
    public class HPUpdateEvent : MonoBehaviour
    {
        public event Action<HPUpdateEvent, HPUpdateEventArgs> OnHPUpdate;

        public void CallHPUpdateEvent(float newHP, float deltaHP, float maxHP)
        {
            HPUpdateEventArgs args = new() { newHP = newHP, deltaHP = deltaHP, maxHP = maxHP };
            OnHPUpdate?.Invoke(this, args);
        }
    }
}