using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;


namespace Tani
{
    public class TurnController :MonoBehaviour
    {
        StateMachine<TurnController.ETurn> stateMachine;

        public StateMachine<TurnController.ETurn> StateMahcine => stateMachine;
        public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();
       private void Awake()
        {
            stateMachine = new StateMachine<ETurn>();
            CS_Init.TrySetResult();
            
        }
        private void Start()
        {
            stateMachine.ChangeState(ETurn.CardTurn);
        }



        private void Update()
        {
            stateMachine.Update(Time.deltaTime);
        }

        public enum ETurn
        {
            Invalid = -1
            ,CardTurn,YusyaTurn,EnemyTurn
                ,TurnMax
        }
    }

}



