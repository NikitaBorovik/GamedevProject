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
        protected Transform shootPosition;
        protected GameObject bulletPrefab;
        protected float coolDown;
        [SerializeField]
        private WeaponSO data;
        protected float timeFromCoolDown;
        protected float damage;
        protected float bulletFlySpeed;

        private void Awake()
        {
            damage = data.damage;
            coolDown = data.coolDown;
            bulletFlySpeed = data.bulletFlySpeed;
            bulletPrefab = data.bullet;
        }
        public ShootEvent ShootEvent { get => shootEvent; }
        public float Cooldown { get => coolDown; set => coolDown = value; }

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
        void Update()
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