using App;
using App.Systems.EnemySpawning;
using App.Systems.Wave;
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
        private IWaveSystem waveSystem;

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

        public virtual void Init(Vector3 position,Transform target, IWaveSystem waveSystem)
        {
            this.target = target;
            this.waveSystem = waveSystem;
            transform.position = position;
            health.HealToMax();
            initialised = true;
            stateMachine.Initialize(spawningState);
        }

        public void Die()
        {
            DropMoney();
            waveSystem.ReportKilled(EnemyData.type);
            objectPool.ReturnToPool(this);
        }

        private void DropMoney()
        {
            if(Random.value <= enemyData.moneyDropChance)
            {
                int count = Random.Range(enemyData.minMoneyDrop,enemyData.maxMoneyDrop + 1);
                for(int i=0;i<count;i++)
                {
                    GameObject money = objectPool.GetObjectFromPool(enemyData.moneyPrefab.PoolObjectType, enemyData.moneyPrefab.gameObject, transform.position).GetGameObject();
                    money.GetComponent<MoneyDropItem>().Init(transform.position);
                }
            }
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

