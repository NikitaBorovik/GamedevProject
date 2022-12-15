using App.Systems.EnemySpawning;
using App.Systems.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy.States;

namespace World.Entity.Enemy
{
    public class RangedEnemy : BaseEnemy
    {
        [SerializeField]
        private EnemyProjectile projectile;

        public EnemyProjectile Projectile => projectile;

        public override void Awake()
        {
            base.Awake();
            attackState = new RangedAttackState(this, stateMachine, FindObjectOfType<ObjectPool>());
        }

        public override void Init(Vector3 position, Transform target, IWaveSystem waveSystem)
        {
            base.Init(position, target, waveSystem);
        }
    }
}

