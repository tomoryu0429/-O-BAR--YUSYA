//using R3.Triggers;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using R3;

//namespace Tani
//{
//    public class HandCardPileOPresenter : Tani.ViewOnlyCardPilePresenter
//    {

      

//        protected override void SetCardViewEvent(ObservableEventTrigger observableEvent)
//        {

//            base.SetCardViewEvent(observableEvent);
//            observableEvent
//                .OnPointerClickAsObservable()
//                .Subscribe(_ =>
//                {
//                    playerData.CardManager
//                    .containers[(int)PlayerCardManager.EPileType.Hand]
//                    .UseCard(observableEvent.gameObject.transform.GetSiblingIndex());
//                }).AddTo(this);

//        }


//    }
//}
