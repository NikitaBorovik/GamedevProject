using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace App.World.Entity.Player
{

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Animator pAnimator;
        [SerializeField]
        private Transform shootPosition;
        [SerializeField]
        private Transform weaponAnchor;
        [SerializeField]
        private Aim aim;
        [SerializeField]
        private PlayerMovement mover;
        [SerializeField]
        private AnimationsController animatorController;
        [SerializeField]
        private float movementSpeed;
        [SerializeField]
        private Rigidbody2D rBody;
        public Transform ShootPosition { get => shootPosition; }
        public Aim Aim { get => aim;}
        public Transform WeaponAnchor { get => weaponAnchor;}
        public AnimationsController AnimatorController { get => animatorController;}
        public Animator PAnimator { get => pAnimator; }
        public float MovementSpeed { get => movementSpeed;}
        public PlayerMovement Mover { get => mover; }
        public Rigidbody2D RBody { get => rBody;}
        public Transform PlayerTransform { get => playerTransform;}
    }
}

