using App;
using App.Systems.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingState : IState
{
    private WaveSystem waveSystem;
    private GameStatesSystem gameStatesSystem;
    public FightingState(GameStatesSystem gameStatesSystem,WaveSystem waveSystem)
    {
        this.gameStatesSystem = gameStatesSystem;
        this.waveSystem = waveSystem;
    }
    public void Enter()
    {
        Debug.Log("Fighting!!!");
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
