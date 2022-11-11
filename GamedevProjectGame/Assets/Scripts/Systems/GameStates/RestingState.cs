using App;
using App.World.Items.Gates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace App.Systems.GameStates
{
    public class RestingState : IState
    {
        GameStatesSystem gameStatesSystem;
        Gates gates;
        private Light2D globalLight;
        private float transitDuration = 2.5f;
        private float elapseTime;
        public RestingState(GameStatesSystem gameStatesSystem, Gates gates, Light2D globalLight)
        {
            this.gameStatesSystem = gameStatesSystem;
            this.gates = gates;
            this.globalLight = globalLight;
        }
        public void Enter()
        {
            gates.Open();
        }

        public void Exit()
        {
            gates.Close();
            elapseTime = 0;
        }

        public void Update()
        {
            if (globalLight.intensity < 1f)
            {
                elapseTime += Time.deltaTime;
                globalLight.intensity = Mathf.Lerp(0.5f, 1f, elapseTime / transitDuration);
            }
        }
    }

}
