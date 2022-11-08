using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.World;
using App.Systems.EnemySpawning;
using App.Systems.Input;
using App.Systems.Wave;
using App.World.Entity.Player.PlayerComponents;

namespace App
{
    public class App : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawningSystem enemySpawningSystem;
        [SerializeField]
        private InputSystem inputSystem;
        [SerializeField]
        private WaveSystem waveSystem;
        [SerializeField]
        private GameStatesSystem gameStatesSystem;
        [SerializeField]
        private ObjectPool objectPool;
        [SerializeField]
        private ObjectsContainer objectsContainer;
        [SerializeField]
        private GameObject enemySpawner;
        [SerializeField]
        private Camera mainCamera;
        private void Start()
        {
            inputSystem.Init(mainCamera,objectsContainer.Player.GetComponent<Player>());
            enemySpawningSystem.Init(waveSystem,objectPool,objectsContainer.Player.transform);
            waveSystem.Init(enemySpawningSystem);
            gameStatesSystem.Init(waveSystem,objectsContainer.Gates.GetComponent<Gates>());
        }

    }
}
