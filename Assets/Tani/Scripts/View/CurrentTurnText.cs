using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Tani 
{
    
    public class CurrentTurnText : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI text;
        [SerializeField]
        TurnController turnController;

        int count = 0;
        bool isInitialized = false;

        //private async void Awake()
        //{
        //    await turnController.CS_Init.Task;
        //    turnController.StateMahcine.Event_Enter += UpdateText;
        //    isInitialized = true;
        //}

        //private void Update()
        //{
        //    if (!isInitialized) return;
            
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        count++;
        //       turnController.StateMahcine.ChangeState((Tani.TurnController.ETurn)(count % (int)Tani.TurnController.ETurn.TurnMax));
        //    }
        //}

        //void UpdateText(Tani.TurnController.ETurn current)
        //{
        //    text.text = $"Turn : {current}";
        //}
    }
}


