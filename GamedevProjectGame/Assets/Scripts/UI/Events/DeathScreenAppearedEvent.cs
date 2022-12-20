using System;
using UnityEngine;

namespace App.World.UI.Events
{
    public class DeathScreenAppearedEvent : MonoBehaviour
    {
        public event Action<DeathScreenAppearedEvent> OnDeathScreenAppeared;

        public void CallAimEvent()
        {
            OnDeathScreenAppeared?.Invoke(this);
        }
    }
}
