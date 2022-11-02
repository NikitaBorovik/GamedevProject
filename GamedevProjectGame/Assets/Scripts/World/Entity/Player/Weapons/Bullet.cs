using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float baseDamage;
        [SerializeField]
        private float speed;
        public float Speed { get => speed; }

        private void OnTriggerEnter2D(Collider2D collision)
        {

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
