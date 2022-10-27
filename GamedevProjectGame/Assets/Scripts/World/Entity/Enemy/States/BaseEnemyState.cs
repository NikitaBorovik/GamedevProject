using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App;
using World.Entity.Enemy;
namespace World.Entity.Enemy.States
{
    public class BaseEnemyState : IState
    {
        protected BaseEnemy baseEnemy;
        protected StateMachine stateMachine;
        public BaseEnemyState(BaseEnemy baseEnemy, StateMachine stateMachine)
        {
            this.baseEnemy = baseEnemy;
            this.stateMachine = stateMachine;
        }
    }
}

