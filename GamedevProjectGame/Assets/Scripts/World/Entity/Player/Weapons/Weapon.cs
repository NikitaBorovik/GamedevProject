using App.Systems.EnemySpawning;
using UnityEngine;
using App.Effects;
using App.Effects.ConcreteEffects;
using App.World.Entity.Player.Events;

namespace App.World.Entity.Player.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        protected ObjectPool objectPool;
        #region Serialized Fields
        [SerializeField] 
        protected BulletHitEvent bulletHitEvent;
        [SerializeField]
        private ShootEvent shootEvent;
        [SerializeField]
        private Transform shootPosition;
        [SerializeField]
        private WeaponSO data;
        #endregion

        #region Sounds
        protected AudioSource audioSource;
        [SerializeField]
        protected AudioClip shootSound;
        #endregion

        #region Parameters
        protected float timeFromCoolDown;
        protected float damage;
        protected float bulletFlySpeed;
        protected float bulletSpread;
        protected int bulletCount;
        protected float coolDown;
        private int pearcingCount;
        protected GameObject bulletPrefab;
        private StatusEffectManager statusEffectManager;
        #endregion

        protected virtual void Awake()
        {
            damage = Data.damage;
            coolDown = Data.coolDown;
            bulletFlySpeed = Data.bulletFlySpeed;
            bulletPrefab = Data.bullet;
            bulletSpread = Data.bulletSpread;
            objectPool = FindObjectOfType<ObjectPool>();
            audioSource = GetComponent<AudioSource>();
            shootSound = Data.shootSound;
            bulletCount = Data.bulletCount;
            pearcingCount = Data.pearcingCount;
            statusEffectManager = FindObjectOfType<StatusEffectManager>();
        }

        public ShootEvent ShootEvent { get => shootEvent; }
        public float Cooldown { get => coolDown; set => coolDown = value; }
        public float Damage { get => damage; set => damage = value; }
        public float BulletFlySpeed { get => bulletFlySpeed; set => bulletFlySpeed = value; }
        public Transform ShootPosition { get => shootPosition; set => shootPosition = value; }
        public WeaponSO Data { get => data; set => data = value; }
        protected int PearcingCount { get => pearcingCount; set => pearcingCount = value; }
        public BaseStatusEffect BulletEffect { get; set; } 

        private void OnEnable()
        {
            ShootEvent.OnShoot += Shoot;
            bulletHitEvent.OnHit += EnableEffectOn;
        }

        private void OnDisable()
        {
            ShootEvent.OnShoot -= Shoot;
            bulletHitEvent.OnHit -= EnableEffectOn;
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

        private void EnableEffectOn(BulletHitEvent target, BulletHitEventArgs args)
        {
            var holder = args.target.GetComponent<IEffectHolder>();
            if (holder is null)
                throw new System.InvalidOperationException("The target is not an Effect Holder.");
            if (args.effect is null) return;
            statusEffectManager.AddHolderToEffect(holder, args.effect);
        }
    }
}