using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;
using Alchemy.Inspector;

namespace Tani
{
    public class TurnController :MonoBehaviour
    {
        [SerializeField]
        List<GameObject> NotifyEnterExitObjs;

        [SerializeField]
        List<GameObject> NotifyUpdateObjs;

        public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();
        public ETurnState CurrentState => current;
        private ETurnState current = ETurnState.Invalid;
        
        private void Awake()
        { 
           CS_Init.TrySetResult();
            
        }
        private async void Start()
        {
            await CS_Init.Task;
            ChangeState(ETurnState.Card);
         
        }

        public void ChangeState(ETurnState newState)
        {
            foreach(var n in NotifyEnterExitObjs)
            {
                if (current == ETurnState.Invalid) continue;
                n.GetComponent<ITurnContollerNotifyEnterExit>()?.OnExit(current);
            }
            current = newState;
            foreach(var n in NotifyEnterExitObjs)
            {

                if (current == ETurnState.Invalid) continue;
                n.GetComponent<ITurnContollerNotifyEnterExit>()?.OnEnter(current);
            }
        }

    
        public enum ETurnState
        {
            Invalid = -1, Card,Yuusya,Enemy,ETurnMax
        }

        

        public interface ITurnContollerNotifyEnterExit
        {
            public abstract void OnEnter(ETurnState state);
            public abstract void OnExit(ETurnState state);
        }
        public interface ITurnContollerNotifyUpdate
        {
            public abstract void OnUpdate(ETurnState state);
        }

       
       

    }

}



