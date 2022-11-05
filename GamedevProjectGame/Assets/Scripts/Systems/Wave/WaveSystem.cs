using App.Systems.EnemySpawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Systems.Wave
{
    public class WaveSystem : MonoBehaviour
    {
        private EnemySpawningSystem enemySpawningSystem;

        //TEMPORARY
        [SerializeField]
        private List<GameObject> enemies;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init(EnemySpawningSystem enemySpawningSystem)
        {
            this.enemySpawningSystem = enemySpawningSystem;
            //TEMPORARY
            enemySpawningSystem.SpawnEnemy(enemies[0]);
        }
    }
}

