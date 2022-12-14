using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;

namespace App.World.Entity.Player.Weapons
{
    public class ParticleDamageZone : MonoBehaviour
    {
        private ParticleGun particleGun;

        public void Init(ParticleGun particleGun)
        {
            this.particleGun = particleGun;
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Health health = collision.GetComponent<Health>();
            if(health == null)
            {
                Debug.LogWarning("No health component on entity affected by particle gun");
                return;
            }
            particleGun.AddAffectedEntity(health);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            Health health = collision.GetComponent<Health>();
            if (health == null)
            {
                Debug.LogWarning("No health component on entity affected by particle gun");
                return;
            }
            particleGun.RemoveAffectedEntity(health);
        }
    }
}

