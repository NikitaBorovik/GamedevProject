using App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Enemy.States
{
    public class SpawningState : BaseEnemyState
    {
        public SpawningState(BaseEnemy baseEnemy, StateMachine stateMachine) : base(baseEnemy, stateMachine) { }
        public override void Enter()
        {
            baseEnemy.StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            //Start spawning animation
            yield return new WaitForSeconds(baseEnemy.EnemyData.spawnAnimationDuration);
            stateMachine.ChangeState(baseEnemy.FollowState);
        }
    }
}

