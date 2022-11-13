using App;
using App.Systems.EnemySpawning;
using App.Systems.Wave;
using App.World.Items;
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
        private DieState dieState;
        private ObjectPool objectPool;
        private IWaveSystem waveSystem;
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Rigidbody2D myRigidbody;
        [SerializeField]
        private Health health;
        [SerializeField]
        protected EnemyData enemyData;
        [SerializeField]
        protected Collider2D myCollider;

        protected StateMachine stateMachine;
        protected BaseEnemyState attackState;

        public Transform Target => target;
        public Rigidbody2D MyRigidbody => myRigidbody;
        public EnemyData EnemyData => enemyData;
        public FollowState FollowState => followState;
        public BaseEnemyState AttackState => attackState;
        public Animator Animator => animator;
        public Collider2D MyCollider => myCollider;
        public SpriteRenderer SpriteRenderer => spriteRenderer;

        public virtual string PoolObjectType => enemyData.type;

        public virtual void Awake()
        {
            initialised = false;
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            stateMachine = new StateMachine();
            followState = new FollowState(this, stateMachine);
            spawningState = new SpawningState(this, stateMachine);
            dieState = new DieState(this,stateMachine);
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
            health.MaxHealth = enemyData.maxHealth;
            health.HealToMax();
            initialised = true;
            if(stateMachine.CurrentState == null)
                stateMachine.Initialize(spawningState);
            else
                stateMachine.ChangeState(spawningState);
        }

        public void Die()
        {
            stateMachine.ChangeState(dieState);
            health.enabled = false;
        }

        public void DyingSequence()
        {
            health.enabled = true;
            StopAllCoroutines();
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

