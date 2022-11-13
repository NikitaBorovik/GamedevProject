using App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Enemy.States
{
    public class MeleeAttackState : BaseEnemyState
    {
        public MeleeAttackState(MeleeEnemy baseEnemy, StateMachine stateMachine) : base(baseEnemy, stateMachine) { }

        public override void Enter()
        {
            baseEnemy.Animator.SetBool("IsAttacking",true);
            baseEnemy.MyRigidbody.mass *= 1000;
            baseEnemy.StartCoroutine(Attack((baseEnemy.Target.position - baseEnemy.transform.position).normalized));
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            baseEnemy.Animator.SetBool("IsAttacking", false);
            baseEnemy.MyRigidbody.mass /= 1000;
        }

        private IEnumerator Attack(Vector3 direction)
        {
            yield return new WaitForSeconds(baseEnemy.EnemyData.timeBetweenAttacks);

            MeleeEnemy meleeEnemy = (MeleeEnemy)baseEnemy;
            meleeEnemy.Attack.SetActive(true);
            meleeEnemy.Attack.transform.right = direction;
            yield return new WaitForSeconds(0.1f);

            meleeEnemy.Attack.SetActive(false);
            stateMachine.ChangeState(baseEnemy.FollowState);
        }
    }
}
