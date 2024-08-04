using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

namespace Tani
{
    public class HandCardPileOPresenter : Tani.ViewOnlyCardPilePresenter
    {

        protected override void Start()
        {
            base.Start();

            CardContainer handContainer = playerData.CardManager.containers[(int)CardManager.EPileType.Hand];

            handContainer
             .OnCardUsed.AsObservable()
             .Subscribe(_ =>
             {

                 //•æ’n‚É’Ç‰Á
                 foreach (var n in handContainer.GetAllCards())
                 {
                     playerData.CardManager.containers[(int)CardManager.EPileType.Discard].AddCard(n);
                 }
                 handContainer.ClearCards();

             }).AddTo(this);
        }
      

        protected override void SetCardViewEvent(ObservableEventTrigger observableEvent)
        {

            base.SetCardViewEvent(observableEvent);
            observableEvent
                .OnPointerClickAsObservable()
                .Subscribe(_ =>
                {
                    playerData.CardManager
                    .containers[(int)CardManager.EPileType.Hand]
                    .UseCard(observableEvent.gameObject.transform.GetSiblingIndex());
                    //TurnController.Instance.ChangeState(TurnController.ETurnState.Yuusya);
                }).AddTo(this);

        }


    }
}
