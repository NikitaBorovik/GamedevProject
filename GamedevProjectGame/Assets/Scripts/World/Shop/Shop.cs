using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.World.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private SellEvent sellEvent;

        public SellEvent SellEvent { get => sellEvent; }
    }
}

