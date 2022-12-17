using App;
using App.Systems.Wave;
using App.World.Items.Gates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace App.Systems.GameStates
{
    public class GameStatesSystem : MonoBehaviour
    {
        private WaveSystem waveSystem;
        private StateMachine gameStateMachine;
        private FightingState fightingState;
        private RestingState restingState;
        private Gates gates;
        [SerializeField]
        private AudioClip fightingMusic;
        [SerializeField]
        private AudioClip restingMusic;
        private AudioSource audioSource;

        public void Init(WaveSystem waveSystem, Gates gates, Light2D light)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume", 0.1f);
            audioSource = GetComponent<AudioSource>();
            this.waveSystem = waveSystem;
            this.gates = gates;
            gates.Init(this);
            gameStateMachine = new StateMachine();
            fightingState = new FightingState(this, waveSystem, light,fightingMusic,audioSource);
            restingState = new RestingState(this, gates, light,restingMusic, audioSource);
            gameStateMachine.Initialize(restingState);
        }

        public void FightingState()
        {
            gameStateMachine.ChangeState(fightingState);
        }
        public void RestingState()
        {
            gameStateMachine.ChangeState(restingState);
        }
        private void Update()
        {
            gameStateMachine.CurrentState.Update();
        }
    }

}
