using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Events
{
    public class MovementEventArgs : EventArgs
    {
        public Vector2 direction;
        public float speed;
    }
}
