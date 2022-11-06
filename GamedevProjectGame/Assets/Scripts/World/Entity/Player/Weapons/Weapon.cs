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
        private float damage;

        private void Awake()
        {
            damage = data.damage;
            coolDown = data.FireRate;
            bulletPrefab = data.bullet;
        }
        public ShootEvent ShootEvent { get => shootEvent; }

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
        public abstract void Shoot(ShootEvent ev);
        public abstract void Shoot();


    }
}