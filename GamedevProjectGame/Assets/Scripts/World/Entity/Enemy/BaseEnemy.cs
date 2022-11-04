using App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy.States;

namespace World.Entity.Enemy
{
    public class BaseEnemy : MonoBehaviour, IKillable
    {
        private bool initialised;
        private Transform target;
        private FollowState followState;

        [SerializeField]
        private Rigidbody2D myRigidbody;
        [SerializeField]
        protected EnemyData enemyData;

        protected StateMachine stateMachine;
        protected BaseEnemyState attackState;

        public Transform Target => target;
        public Rigidbody2D MyRigidbody => myRigidbody;
        public EnemyData EnemyData => enemyData;
        public FollowState FollowState => followState;
        public BaseEnemyState AttackState => attackState;

        public virtual void Awake()
        {
            initialised = false;
            stateMachine = new StateMachine();
            followState = new FollowState(this, stateMachine);
        }

        void Update()
        {
            if(initialised)
                stateMachine.CurrentState.Update();
        }

        public void Init(Transform target)
        {
            this.target = target;
            initialised = true;
            stateMachine.Initialize(FollowState);
        }

        public void Die()
        {
            //TODO: change to getting back into object pool
            Destroy(gameObject);
        }
    }
}

