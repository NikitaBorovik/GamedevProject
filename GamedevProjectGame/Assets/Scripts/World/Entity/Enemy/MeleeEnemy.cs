using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy.States;

namespace World.Entity.Enemy
{
    public class MeleeEnemy : BaseEnemy
    {
        [SerializeField]
        private GameObject attack;
        public GameObject Attack => attack;
        public override void Awake()
        {
            base.Awake();
            attackState = new MeleeAttackState(this, stateMachine);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Detected collision");
        }
    }
}

