using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace App.World.Entity.Player.Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private ShootEvent shootEvent;
        [SerializeField]
        private Transform shootPosition;
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private float coolDown;
        private float timeFromCoolDown;

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
        public void Shoot()
        {
            if (timeFromCoolDown > coolDown)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bullet.GetComponent<Bullet>().Speed;
                timeFromCoolDown = 0.0f;
            }
        }

    }
}