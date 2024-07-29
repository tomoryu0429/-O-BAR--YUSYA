using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncStateMachine : MonoBehaviour
{
    AsyncState CurrentState = null;

    async UniTaskVoid Switch()
    {
        if(CurrentState != null)
        {
            await CurrentState.EnterAsync();
        }
    }
}
