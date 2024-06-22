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

        int count = 0;

        private void Awake()
        {
            Tani.TurnController.Instance.StateMahcine.Event_Enter += UpdateText;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                count++;
                Tani.TurnController.Instance.StateMahcine.ChangeState((Tani.TurnController.ETurn)(count % (int)Tani.TurnController.ETurn.TurnMax));
            }
        }

        void UpdateText(Tani.TurnController.ETurn current)
        {
            text.text = $"Turn : {current}";
        }
    }
}


