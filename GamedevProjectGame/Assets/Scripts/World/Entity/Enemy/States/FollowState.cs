using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App;
namespace World.Entity.Enemy.States
{
    public class FollowState : BaseEnemyState
    {

        public FollowState(BaseEnemy baseEnemy, StateMachine stateMachine) : base(baseEnemy, stateMachine) { }

        public void Enter()
        {
            //
        }

        public void Update() 
        { 
            baseEnemy.MyRigidbody.velocity = (baseEnemy.Target.position - baseEnemy.transform.position).normalized * baseEnemy.EnemyData.speed;
        }

        public void Exit() { }
    }
}

