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
        [SerializeField]
        private Explosion explosion;
        public override string PoolObjectType => "GrenadeBullet";

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
            Explode();
        }

        private void Explode()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            var newExplosion = objectPool.GetObjectFromPool(explosion.PoolObjectType,explosion.gameObject,transform.position).GetGameObject();
            newExplosion.GetComponent<Explosion>().Init(transform.position, 1f, damage);
            objectPool.ReturnToPool(this);
        }
        
        public override void Init(float damage)
        {
            base.Init(damage);
            
        }
    }
}
