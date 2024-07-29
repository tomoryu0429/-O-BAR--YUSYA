using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AsyncState 
{
    public AsyncState(AsyncStateMachine stateMachine) { StateMachine = stateMachine; }
    protected AsyncStateMachine StateMachine { get; }

    public abstract UniTask EnterAsync();
    public abstract UniTask ExitAsync();
}
