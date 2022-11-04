using App.World.Entity.Player.Events;
using App.World.Entity.Player.Weapons;
using UnityEngine;


namespace App.World.Entity.Player.PlayerComponents
{

    public class Player : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Animator pAnimator;
        [SerializeField]
        private Transform shootPosition;
        [SerializeField]
        private Transform weaponAnchor;
        [SerializeField]
        private float movementSpeed;
        [SerializeField]
        private GameObject curWeaponObj;
        private Weapon weapon;
        [SerializeField]
        private AimEvent aimEvent;
        [SerializeField]
        private StandEvent standEvent;
        [SerializeField]
        private MovementEvent movementEvent;
        #endregion

        #region Properties
        public Transform ShootPosition { get => shootPosition; }
        public Animator PAnimator { get => pAnimator; }
        public Transform PlayerTransform { get => playerTransform;}
        public Transform WeaponAnchor { get => weaponAnchor;}
        public AimEvent AimEvent { get => aimEvent; set => aimEvent = value; }
        public StandEvent StandEvent { get => standEvent; set => standEvent = value; }
        public MovementEvent MovementEvent { get => movementEvent; set => movementEvent = value; }
        public float MovementSpeed { get => movementSpeed;}
        public Weapon Weapon { get => weapon;}
        #endregion
        private void Awake()
        {
            weapon = curWeaponObj.GetComponent<Weapon>();
        }
        
    }
}

