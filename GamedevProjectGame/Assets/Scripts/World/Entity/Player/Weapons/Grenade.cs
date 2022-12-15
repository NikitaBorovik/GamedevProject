using App.Systems.EnemySpawning;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;

namespace App.World.Entity.Player.Weapons
{
    public class Grenade : BaseBullet
    {
        private ParticleSystem explosion;
        public override string PoolObjectType => "GrenadeBullet";

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            Explode();
        }

        private void Explode()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            explosion.Play();
        }
        
        public override void Init(float damage)
        {
            base.Init(damage);
            explosion = GetComponentInChildren<ParticleSystem>();
        }
    }
}
