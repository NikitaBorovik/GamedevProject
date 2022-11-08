using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private float damage;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {

        }
        public void Init(float damage)
        {
            this.damage = damage;
        }
    }
}
