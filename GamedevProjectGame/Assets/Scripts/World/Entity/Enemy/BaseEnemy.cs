using App;
using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy.States;

namespace World.Entity.Enemy
{
    public abstract class BaseEnemy : MonoBehaviour, IKillable, IObjectPoolItem
    {
        private bool initialised;
        private Transform target;
        private FollowState followState;
        private SpawningState spawningState;
        private ObjectPool objectPool;

        [SerializeField]
        private Rigidbody2D myRigidbody;
        [SerializeField]
        private Health health;
        [SerializeField]
        protected EnemyData enemyData;

        protected StateMachine stateMachine;
        protected BaseEnemyState attackState;

        public Transform Target => target;
        public Rigidbody2D MyRigidbody => myRigidbody;
        public EnemyData EnemyData => enemyData;
        public FollowState FollowState => followState;
        public BaseEnemyState AttackState => attackState;

        public virtual string PoolObjectType => enemyData.type;

        public virtual void Awake()
        {
            initialised = false;
            stateMachine = new StateMachine();
            followState = new FollowState(this, stateMachine);
            spawningState = new SpawningState(this, stateMachine);
        }

        void Update()
        {
            if(initialised)
                stateMachine.CurrentState.Update();
        }

        public void Init(Vector3 position,Transform target)
        {
            this.target = target;
            transform.position = position;
            health.HealToMax();
            initialised = true;
            stateMachine.Initialize(spawningState);
        }

        public void Die()
        {
            objectPool.ReturnToPool(this);
        }

        public void GetFromPool(ObjectPool pool)
        {
            objectPool = pool;
            gameObject.SetActive(true);
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }

        public GameObject GetGameObject()
        {
            return(gameObject);
        }
    }
}

