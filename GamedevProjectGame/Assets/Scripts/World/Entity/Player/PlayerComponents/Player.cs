using App.World.Entity.Player.Events;
using App.World.Entity.Player.Weapons;
using UnityEngine;
using World.Entity;
using App.Upgrades;

namespace App.World.Entity.Player.PlayerComponents
{
    #region Required
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Transform))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(PlayerAnimationsController))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Aim))]
    [RequireComponent(typeof(Stand))]
    #endregion
    public class Player : MonoBehaviour , IKillable, IUpgradable
    {
        #region Components
        private Transform playerTransform;
        private Animator pAnimator;
        private Health health;
        [SerializeField]
        private PlayerDataSO playerData;
        #endregion

        #region Weapon
        [SerializeField]
        private Transform shootPosition;
        [SerializeField]
        private Transform weaponAnchor;
        [SerializeField]
        private GameObject curWeaponObj;
        private Weapon weapon;
        #endregion

        #region Events
        [SerializeField]
        private AimEvent aimEvent;
        [SerializeField]
        private StandEvent standEvent;
        [SerializeField]
        private MovementEvent movementEvent;
        #endregion

        #region Parameters
        private float movementSpeed;
        private int money;
        #endregion

        #region Properties
        public Transform ShootPosition { get => shootPosition; }
        public Animator PAnimator { get => pAnimator; }
        public Transform PlayerTransform { get => playerTransform;}
        public Transform WeaponAnchor { get => weaponAnchor;}
        public AimEvent AimEvent { get => aimEvent;}
        public StandEvent StandEvent { get => standEvent;}
        public MovementEvent MovementEvent { get => movementEvent;}
        public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        public Weapon Weapon { get => weapon;}
        public int Money { get => money; set => money = value; }
        public Health Health { get => health; set => health = value; }
        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            playerTransform = GetComponent<Transform>();
            pAnimator = GetComponent<Animator>();
            health = GetComponent<Health>();
            weapon = curWeaponObj.GetComponent<Weapon>();
            movementSpeed = playerData.speed;
            health.MaxHealth = playerData.maxHealth;
        }
        public void Die()
        {
            throw new System.NotImplementedException();
        }

        public void EnableUpgrade(BaseUpgrade upgrade)
        {
            upgrade.Enable(this);
        }

        public void UpdateUpgrade(BaseUpgrade upgrade)
        {
            upgrade.UpdateUpgrade(this);
        }

        public void DisableUpgrade(BaseUpgrade upgrade)
        {
            upgrade.Disable(this);
        }
    }
}

