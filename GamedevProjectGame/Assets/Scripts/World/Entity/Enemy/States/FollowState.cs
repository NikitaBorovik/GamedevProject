using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App;
using App.World.Entity.Enemy.States;

namespace App.World.Entity.Enemy.States
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
                stateMachine.ChangeState(baseEnemy.AttackState);
            }
            else
            {
                baseEnemy.MyRigidbody.velocity = (baseEnemy.Target.position - baseEnemy.transform.position).normalized * baseEnemy.EnemyData.speed;
                SetMoveAnimationParams(baseEnemy.MyRigidbody.velocity.x);
            }
        }

        public override void Exit() 
        {
            baseEnemy.MyRigidbody.velocity = Vector2.zero;
        }

        private void SetMoveAnimationParams(float vx)
        {

            //if(baseEnemy.transform.position.x > baseEnemy.Target.position.x)
            if (vx < 0)
            {
                baseEnemy.Animator.SetBool("MovingRight", false);
                baseEnemy.Animator.SetBool("MovingLeft", true);
            }
            else
            {
                baseEnemy.Animator.SetBool("MovingRight", true);
                baseEnemy.Animator.SetBool("MovingLeft", false);
            }
        }
    }
}

