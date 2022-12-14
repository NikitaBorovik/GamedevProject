using App;
using App.Systems.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace App.Systems.GameStates
{
    public class FightingState : IState
    {
        private WaveSystem waveSystem;
        private GameStatesSystem gameStatesSystem;
        private Light2D globalLight;
        private float transitDuration = 2.5f;
        private float elapseTime;
        public FightingState(GameStatesSystem gameStatesSystem, WaveSystem waveSystem, Light2D globalLight)
        {
            this.gameStatesSystem = gameStatesSystem;
            this.waveSystem = waveSystem;
            this.globalLight = globalLight;
        }
        public void Enter()
        {
            Debug.Log("Fighting!!!");
            waveSystem.StartWave();

        }
        public void Exit()
        {
            elapseTime = 0;
        }

        public void Update()
        {
            Debug.Log("Fighting!!!");
            if (globalLight.intensity > 0.5f)
            {
                elapseTime += Time.deltaTime;
                globalLight.intensity = Mathf.Lerp(1f, 0.5f, elapseTime / transitDuration);
            }

        }
    }
}

