using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ShootEvent shootEvent;
        [SerializeField]
        private Transform shootPosition;
        protected GameObject bulletPrefab;
        protected float coolDown;
        [SerializeField]
        private WeaponSO data;
        protected ObjectPool objectPool;
        protected float timeFromCoolDown;
        protected float damage;
        protected float bulletFlySpeed;
        protected float bulletSpread;
        protected int bulletCount;

        protected virtual void Awake()
        {
            damage = Data.damage;
            coolDown = Data.coolDown;
            bulletFlySpeed = Data.bulletFlySpeed;
            bulletPrefab = Data.bullet;
            bulletSpread = Data.bulletSpread;
            objectPool = FindObjectOfType<ObjectPool>();
            bulletCount = Data.bulletCount;
        }

        public ShootEvent ShootEvent { get => shootEvent; }
        public float Cooldown { get => coolDown; set => coolDown = value; }
        public float Damage { get => damage; set => damage = value; }
        public float BulletFlySpeed { get => bulletFlySpeed; set => bulletFlySpeed = value; }
        public Transform ShootPosition { get => shootPosition; set => shootPosition = value; }
        public WeaponSO Data { get => data; set => data = value; }

        private void OnEnable()
        {
            ShootEvent.OnShoot += Shoot;
        }

        private void OnDisable()
        {
            ShootEvent.OnShoot -= Shoot;
        }
        void Start()
        {
            timeFromCoolDown = coolDown;

        }
        protected void Update()
        {
            timeFromCoolDown += Time.deltaTime;
        }
        public void Shoot(ShootEvent ev)
        {
            Shoot();
        }
        public abstract void Shoot();


    }
}