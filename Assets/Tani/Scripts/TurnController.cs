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
    //ターンを制御するクラス(シングルトン)
    public class TurnController :SingletonMonoBehavior<TurnController>
    {
        [SerializeField]
        List<GameObject> NotifyEnterExitObjs;

        [SerializeField]
        List<GameObject> NotifyUpdateObjs;

        public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();
        public ETurnState CurrentState => current;
        private ETurnState current = ETurnState.Invalid;
        
        protected override void  Awake()
        {
            base.Awake();
           CS_Init.TrySetResult();
            
        }
        private  void Start()
        {
           
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



