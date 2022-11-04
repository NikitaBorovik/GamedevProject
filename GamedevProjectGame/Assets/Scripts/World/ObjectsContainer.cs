using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.World
{
    public class ObjectsContainer : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;

        public GameObject Player { get => player; }
    }
}

