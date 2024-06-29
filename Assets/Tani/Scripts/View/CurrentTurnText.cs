using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tani 
{
    
    public class CurrentTurnText : MonoBehaviour,TurnController.ITurnContollerNotifyEnterExit
    {
        [SerializeField]
        TextMeshProUGUI text;
        [SerializeField]
        TurnController turnController;

        int count = 0;
        bool isInitialized = false;

        private async void Awake()
        {
            await turnController.CS_Init.Task;

            isInitialized = true;
        }

        private void Update()
        {
            if (!isInitialized) return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                count++;
                turnController.ChangeState((Tani.TurnController.ETurnState)(count % (int)Tani.TurnController.ETurnState.ETurnMax));
            }
        }

        void TurnController.ITurnContollerNotifyEnterExit.OnEnter(TurnController.ETurnState state)
        {
            string stateName = state switch
            {
                TurnController.ETurnState.Invalid => throw new System.NotImplementedException(),
                TurnController.ETurnState.Card => "カードターン",
                TurnController.ETurnState.Yuusya => "勇者ターン",
                TurnController.ETurnState.Enemy => "エネミーターン",
                TurnController.ETurnState.ETurnMax => throw new System.NotImplementedException(),
                _ => throw new System.NotImplementedException()
            };
            text.text = stateName;
        }

        public void OnExit(TurnController.ETurnState state)
        {
            // throw new System.NotImplementedException();
        }


    }
}


