using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.Entity.Enemy
{
    public class BaseEnemy : MonoBehaviour, IKillable
    {
        bool initialised;

        private Transform target;
        [SerializeField]
        private Rigidbody2D myRigidbody;
        [SerializeField]
        private EnemyData enemyData;

        public Transform Target => target;
        public Rigidbody2D MyRigidbody => myRigidbody;
        public EnemyData EnemyData => enemyData;

        public void Awake()
        {
            initialised = false;
        }

        void Update()
        {

        }

        public void Init(Transform target)
        {
            this.target = target;
            myRigidbody = GetComponent<Rigidbody2D>();
            initialised = true;
        }

        public void Die()
        {
            //TODO: change to getting back into object pool
            Destroy(gameObject);
        }
    }
}

