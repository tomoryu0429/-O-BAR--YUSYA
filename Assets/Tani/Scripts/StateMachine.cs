using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StateMachine <T>
{
    public StateMachine(T owner)
    {
        Owner = owner;
    }

    public T Owner { get; }

    public abstract class State 
    {
        public State(T owner)
        {
            Owner = owner;
        }
        private T Owner { get; }
        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
    }

    State currentState = null;

    public void ChangeState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void SM_Update(float deltaTime)
    {
        currentState?.Tick(deltaTime);
    }


}
