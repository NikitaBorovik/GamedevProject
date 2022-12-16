using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;

namespace App.World.Entity.Player.Weapons
{
    public abstract class BaseBullet : MonoBehaviour, IObjectPoolItem
    {
        protected float damage;
        protected ObjectPool objectPool;
        public virtual string PoolObjectType => "DefaultBullet";

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (!gameObject.activeSelf)
                return;
            Health targetHealt = collision.GetComponent<Health>();
            if (targetHealt == null)
            {
               // Debug.Log("No Health component on shot target");
               // Debug.Log(collision.gameObject.name);
                return;
            }
            targetHealt.TakeDamage(damage);
            objectPool.ReturnToPool(this);
        }
        public virtual void Init(float damage)
        {
            this.damage = damage;
            GetComponent<TimeToLive>().Init();
        }

        public virtual void GetFromPool(ObjectPool pool)
        {
            objectPool = pool;
            gameObject.SetActive(true);
        }

        public virtual void ReturnToPool()
        {
            gameObject.SetActive(false);
        }

        public virtual GameObject GetGameObject()
        {
            return (gameObject);
        }
    }
}
