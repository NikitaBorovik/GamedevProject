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
        private List<string> enemyTypes;
        private int enemiesAlive = 0;
        private int dangerLevelLeft;

        [SerializeField]
        private float minTimeBetweenSpawns;
        [SerializeField]
        private float maxTimeBetweenSpawns;
        [SerializeField]
        private List<BaseEnemy> enemies;

        public void StartWave()
        {
            StartCoroutine(Wave());
        }

        public void Init(EnemySpawningSystem enemySpawningSystem, GameStatesSystem gameStatesSystem)
        {
            this.enemySpawningSystem = enemySpawningSystem;
            this.gameStatesSystem = gameStatesSystem;   
        }

        public IEnumerator Wave()
        {
            dangerLevelLeft = CalculateTotalDangerLevel(waveNum);
            while(dangerLevelLeft > 0)
            {
                int enemyIndex = Random.Range(0, enemies.Count);
                BaseEnemy randomEnemy = enemies[enemyIndex];
                enemySpawningSystem.SpawnEnemy(randomEnemy.gameObject);
                dangerLevelLeft -= randomEnemy.EnemyData.dangerLevel;
                enemiesAlive++;
                yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns,maxTimeBetweenSpawns));
            }
        }

        private int CalculateTotalDangerLevel(int waveNum)
        {
            return (int)((1 + waveNum/10.0) * 145);
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
            gameStatesSystem.RestingState();
        }
    }
}

