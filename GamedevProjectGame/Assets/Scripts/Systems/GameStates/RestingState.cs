using App;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingState : IState
{
    GameStatesSystem gameStatesSystem;
    Gates gates;
    public RestingState(GameStatesSystem gameStatesSystem,Gates gates)
    {
        this.gameStatesSystem = gameStatesSystem;
        this.gates = gates;
    }
    public void Enter()
    {
        gates.Open();
    }

    public void Exit()
    {
        gates.Close();
    }

    public void Update()
    {
        
    }
}
