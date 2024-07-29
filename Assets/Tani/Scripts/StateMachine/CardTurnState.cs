using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTurnState : StateMachine<TurnStateMachine>.State
{
    public CardTurnState(StateMachine<TurnStateMachine> stateMachine) : base(stateMachine)
    {
    }
}
