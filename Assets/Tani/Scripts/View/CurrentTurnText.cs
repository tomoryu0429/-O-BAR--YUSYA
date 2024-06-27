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

        public void OnEnter(TurnController.ETurnState state)
        {
            text.text = $"Turn : {state.ToString()}";
        }

        public void OnExit(TurnController.ETurnState state)
        {
           // throw new System.NotImplementedException();
        }


    }
}


