using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class StateMachine <T>  : MonoBehaviour
{
     public class State
     {
        public StateMachine<T> StateMachine { get; set; }

        public virtual void Enter() { }
        public virtual void Tick(float deltaTime) { }
        public virtual void Exit() { }

     }

    protected State current = null;
    public State CurrentState => current;

    public void ChangeState<S>() where S : State,new()
    {
        CurrentState?.Exit();
        current = new S();
        current.StateMachine = this;
        current?.Enter();

    }

    protected virtual void Update()
    {
        current?.Tick( Time.deltaTime);
    }





}
