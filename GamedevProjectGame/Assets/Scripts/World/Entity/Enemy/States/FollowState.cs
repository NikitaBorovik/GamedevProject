using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App;
namespace World.Entity.Enemy.States
{
    public class FollowState : BaseEnemyState
    {

        public FollowState(BaseEnemy baseEnemy, StateMachine stateMachine) : base(baseEnemy, stateMachine) { }

        public override void Enter()
        {
            
        }

        public override void Update() 
        {
            if ((baseEnemy.Target.position - baseEnemy.transform.position).magnitude <= baseEnemy.EnemyData.attackRange)
            {
                //Debug.Log("Attacking");
                stateMachine.ChangeState(baseEnemy.AttackState);
            }
            else
            {
                baseEnemy.MyRigidbody.velocity = (baseEnemy.Target.position - baseEnemy.transform.position).normalized * baseEnemy.EnemyData.speed;
            }
        }

        public override void Exit() 
        {
            baseEnemy.MyRigidbody.velocity = Vector2.zero;
        }
    }
}

