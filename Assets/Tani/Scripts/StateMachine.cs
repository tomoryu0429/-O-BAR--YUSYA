using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class StateMachine <T>  
{
    public event UnityAction<T> Event_Enter = null;
    public event UnityAction<T,float> Event_Tick = null;
    public event UnityAction<T> Event_Exit = null;



    protected T currentState = (T)System.Enum.ToObject(typeof(T),-1);
    public T CurrentState => currentState;

    public void ChangeState(T state)
    {
        bool current_isDefined = System.Enum.IsDefined(typeof(T), currentState);
        bool next_isDefined = System.Enum.IsDefined(typeof(T), state);

        if (current_isDefined) Event_Exit?.Invoke(currentState);
        currentState = state;
        if (next_isDefined) Event_Enter?.Invoke(state);
    }

    public   void Update(float deltaTime)
    {
        if (System.Enum.IsDefined(typeof(T), currentState))
        {
            Event_Tick?.Invoke(currentState, deltaTime);
        }
    }



}
