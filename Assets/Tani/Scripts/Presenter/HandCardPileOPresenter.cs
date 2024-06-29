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

            switch (state)
            {
                case TurnController.ETurnState.Invalid:
                    break;
                case TurnController.ETurnState.Card:
                    playerData.CardManager.DrawCard();
                    playerData.CardManager.DrawCard();
                    playerData.CardManager.DrawCard();
                    break;
                case TurnController.ETurnState.Yuusya:
                    //ターン開始時手札のカードを墓地に移動
                    int cardNum = playerData.CardManager.containers[(int)CardManager.EPileType.Hand].Count;

                    List<AutoEnum.ECardID> moveDatas = new();
                    for(int i =0; i < cardNum; i++)
                    {
                        moveDatas.Add(playerData.CardManager.containers[(int)CardManager.EPileType.Hand].GetAt(i));
                    }

                    //手札をクリア
                    playerData.CardManager.containers[(int)CardManager.EPileType.Hand].ClearCards();
                    //墓地に追加
                    foreach(var n in moveDatas)
                    {
                        playerData.CardManager.containers[(int)CardManager.EPileType.Discard].AddCard(n);
                    }
                    break;
                case TurnController.ETurnState.Enemy:
                    break;
                case TurnController.ETurnState.ETurnMax:
                    break;
            }
        }

        public void OnExit(TurnController.ETurnState state)
        {
            //throw new System.NotImplementedException();
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
                    TurnController.Instance.ChangeState(TurnController.ETurnState.Yuusya);
                }).AddTo(this);

        }


    }
}
