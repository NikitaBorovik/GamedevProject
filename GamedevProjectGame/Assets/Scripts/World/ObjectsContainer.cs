using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.World
{
    public class ObjectsContainer : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;
        [SerializeField]
        private GameObject gates;
        [SerializeField]
        private GameObject shop;
        public GameObject Player { get => player; }
        public GameObject Gates { get => gates;}
        public GameObject Shop { get => shop;}
    }
}

