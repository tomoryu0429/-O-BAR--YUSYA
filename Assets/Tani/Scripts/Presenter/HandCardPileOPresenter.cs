using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

namespace Tani
{
    public class HandCardPileOPresenter : Tani.ViewOnlyCardPilePresenter,TurnController.ITurnContollerNotifyEnterExit
    {
        bool CanUseCard = false;
        public  void OnEnter(TurnController.ETurnState state)
        {
            CanUseCard = state == TurnController.ETurnState.Card;
        }

        public void OnExit(TurnController.ETurnState state)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetCardViewEvent(ObservableEventTrigger observableEvent)
        {
            base.SetCardViewEvent(observableEvent);
            observableEvent
                .OnPointerClickAsObservable()
                .Subscribe(_ =>
                {
                    if (!CanUseCard) return;
                    playerData.CardManager
                    .containers[(int)CardManager.EPileType.Hand]
                    .UseCard(observableEvent.gameObject.transform.GetSiblingIndex());
                }).AddTo(this);

        }


    }
}
