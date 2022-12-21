using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity;
using App.World.Entity.Player.Events;
using App.Effects;

namespace App.World.Entity.Player.Weapons
{
    public class BaseBullet : MonoBehaviour, IObjectPoolItem
    {
        //public static BulletHitEvent bulletHitEvent;
        private BulletHitEvent bulletHitEvent;

        private BaseStatusEffect bulletEffect;
        protected float damage;
        protected float pearcingCount;
        protected ObjectPool objectPool;
        [SerializeField]
        protected string poolObjectType;
        public string PoolObjectType => poolObjectType;

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (!gameObject.activeSelf)
                return;
            if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            {
                objectPool.ReturnToPool(this);
                return;
            }
            Health targetHealt = collision.GetComponent<Health>();
            if (targetHealt == null)
            {
                return;
            }
            targetHealt.TakeDamage(damage);
            bulletHitEvent.CallBulletHitEvent(collision.gameObject, bulletEffect);
            if (pearcingCount > 0)
            {
                pearcingCount--;
            }
            else
            {
                objectPool.ReturnToPool(this);
            }
 
        }
        public virtual void Init(float damage, int pearcingCount, BaseStatusEffect bulletEffect, BulletHitEvent bulletHitEvent)
        {
            this.damage = damage;
            this.pearcingCount = pearcingCount;
            this.bulletEffect = bulletEffect;
            this.bulletHitEvent = bulletHitEvent;
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
