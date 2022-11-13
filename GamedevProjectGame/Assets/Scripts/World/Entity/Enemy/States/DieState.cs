using App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Enemy.States
{
    public class DieState : BaseEnemyState
    {
        public DieState(BaseEnemy baseEnemy, StateMachine stateMachine) : base(baseEnemy, stateMachine) { }

        public override void Enter()
        {
            baseEnemy.MyCollider.enabled = false;
            baseEnemy.Animator.SetBool("IsSpawning", false);
            baseEnemy.Animator.SetBool("IsAttacking", false);
            baseEnemy.Animator.SetBool("IsDying", true);
        }

        public override void Exit()
        {
            baseEnemy.MyCollider.enabled = true;
            baseEnemy.Animator.SetBool("IsDying", false);
            baseEnemy.Animator.SetBool("MovingRight", false);
            baseEnemy.Animator.SetBool("MovingLeft", false);
        }
    }
}
