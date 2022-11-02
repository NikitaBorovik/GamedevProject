using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Events
{
    public class AimEventArgs : EventArgs
    {
        public float angle;
        public float playerPos;
        public float mousePos;
    }
}