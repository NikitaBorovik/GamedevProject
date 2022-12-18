using System;

namespace App.World.Entity.Player.Events
{
    public class HPUpdateEventArgs : EventArgs
    {
        public float newHP;
        public float deltaHP;
        public float maxHP;
    }
}