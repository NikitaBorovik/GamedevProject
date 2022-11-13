using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;

namespace App.World.Entity.Player.Weapons
{
    public class Bullet : MonoBehaviour, IObjectPoolItem
    {
        private float damage;
        private ObjectPool objectPool;
        public string PoolObjectType => "GatlingBullet";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!gameObject.activeSelf)
                return;
            Health targetHealt = collision.GetComponent<Health>();
            if (targetHealt == null)
            {
                Debug.Log("No Health component on shot target");
                return;
            }
            if(targetHealt.CurrentHealth > 0)
                targetHealt.TakeDamage(damage);
            objectPool.ReturnToPool(this);
        }
        public void Init(float damage)
        {
            this.damage = damage;
            GetComponent<TimeToLive>().Init();
        }

        public void GetFromPool(ObjectPool pool)
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
        }
    }
}
