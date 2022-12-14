using App.Systems.EnemySpawning;
using App.Systems.GameStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Entity.Enemy;

namespace App.Systems.Wave
{
    public class WaveSystem : MonoBehaviour, IWaveSystem
    {
        private int waveNum = 1;
        private EnemySpawningSystem enemySpawningSystem;
        private GameStatesSystem gameStatesSystem;
        private int enemiesAlive = 0;
        private int dangerLevelLeft;
        private int totalDangerLevel = 200;
        private List<BaseEnemy> allowedEnemies = new List<BaseEnemy>();

        [SerializeField]
        private float minTimeBetweenSpawns;
        [SerializeField]
        private float maxTimeBetweenSpawns;
        [SerializeField]
        private List<BaseEnemy> enemies;

        public void StartWave()
        {
            allowedEnemies = enemies.FindAll(e => e.EnemyData.firstSpawningWave >= waveNum);
            StartCoroutine(Wave());
        }

        public void Init(EnemySpawningSystem enemySpawningSystem, GameStatesSystem gameStatesSystem)
        {
            this.enemySpawningSystem = enemySpawningSystem;
            this.gameStatesSystem = gameStatesSystem;   
        }

        public IEnumerator Wave()
        {
            dangerLevelLeft = totalDangerLevel;
            while(dangerLevelLeft > 0)
            {
                SpawnSubWave();
                yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns,maxTimeBetweenSpawns));
            }
        }

        private void SpawnSubWave()
        {
            int dangerDiff = (int)(totalDangerLevel * 0.1);
            int startingDangerLevel = dangerLevelLeft;
            while(dangerLevelLeft > startingDangerLevel - dangerDiff)
            {
                int enemyIndex = Random.Range(0, allowedEnemies.Count);
                Debug.Log(allowedEnemies.Count);
                BaseEnemy randomEnemy = allowedEnemies[enemyIndex];
                enemySpawningSystem.SpawnEnemy(randomEnemy.gameObject);
                dangerLevelLeft -= randomEnemy.EnemyData.dangerLevel;
                enemiesAlive++;
            }
        }

        private void CalculateNextDangerLevel()
        {
            totalDangerLevel = (int)(totalDangerLevel * 1.2);
        }

        public void ReportKilled(string enemyType)
        {
            enemiesAlive--;
            if (dangerLevelLeft <= 0 && enemiesAlive <= 0)
                EndWave();
        }

        private void EndWave()
        {
            Debug.Log("Wave ended");
            waveNum++;
            CalculateNextDangerLevel();
            gameStatesSystem.RestingState();
        }
    }
}

