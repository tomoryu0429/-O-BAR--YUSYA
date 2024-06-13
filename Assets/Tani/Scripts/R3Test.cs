using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using R3;
using R3.Triggers;

namespace Tani
{
    public class R3Test : MonoBehaviour
    {
        [SerializeField]
        ObservableEventTrigger eventTrigger;

        public ObservableEventTrigger ObservableEventTrigger => eventTrigger;

        private void Start()
        {
            
            eventTrigger
                .OnPointerClickAsObservable()
                .Subscribe(_ => print("click"))
                .AddTo(this);

            PlayerData.Instance.CardManager.Hand.OnCardAdded += (id) => print(id.ToString());
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Meet);
        }
    }
}

