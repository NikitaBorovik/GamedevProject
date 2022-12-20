using App.Systems.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy.States;

namespace World.Entity.Enemy
{
    public class MeleeEnemy : BaseEnemy
    {
        [SerializeField]
        private DamagePlayer attack;
        public GameObject Attack => attack.gameObject;
        public override void Awake()
        {
            base.Awake();
            attackState = new MeleeAttackState(this, stateMachine);
        }

        public override void Init(Vector3 position, Transform target, IWaveSystem waveSystem, float hpMultiplier)
        {
            base.Init(position, target, waveSystem, hpMultiplier);
            attack.Init(enemyData.damage);
        }
    }
}

