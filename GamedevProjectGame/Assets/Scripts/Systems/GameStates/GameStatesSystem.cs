using App;
using App.Systems.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesSystem : MonoBehaviour
{
    private WaveSystem waveSystem;

    private StateMachine gameStateMachine;
    private FightingState fightingState;
    private RestingState restingState;
    private Gates gates;
    
    public void Init(WaveSystem waveSystem,Gates gates)
    {
        this.waveSystem = waveSystem;
        this.gates = gates;
        gates.Init(this);
        gameStateMachine = new StateMachine();
        fightingState = new FightingState(this, waveSystem);
        restingState = new RestingState(this,gates);
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
}
