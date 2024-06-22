using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.Events;
namespace Tani
{
    public class TurnController : SingletonMonoBehavior<TurnController>
    {
        StateMachine<TurnController.ETurn> stateMachine;

        public StateMachine<TurnController.ETurn> StateMahcine => stateMachine;

        protected override void Awake()
        {
            base.Awake();
            stateMachine = new StateMachine<ETurn>();
            
            
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



