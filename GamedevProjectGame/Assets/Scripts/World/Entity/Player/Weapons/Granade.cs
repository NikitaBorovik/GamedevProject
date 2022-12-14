using App.Systems.EnemySpawning;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;

namespace App.World.Entity.Player.Weapons
{
    public class Granade : Bullet
    {
        private float damage;
        private ObjectPool objectPool;
        public string PoolObjectType => "GatlingBullet";

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            Explose();
        }

        private void Explose()
        {
            throw new NotImplementedException();
        }

        public void Init(float damage)
        {
            this.damage = damage;
            GetComponent<TimeToLive>().Init();
        }

        /*public void GetFromPool(ObjectPool pool)
        {
            objectPool = pool;
            gameObject.SetActive(true);
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }

        public GameObject GetGameObject()
        {
            return (gameObject);
        }*/
    }
}
