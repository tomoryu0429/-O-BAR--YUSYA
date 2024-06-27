using Alchemy.Inspector;
using R3.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

namespace Tani
{
    public class ViewOnlyCardPilePresenter : Tani.CardViewGenerator
    {
        [SerializeField]
        [AssetsOnly]
        GameObject toolTipPrefab;

        private GameObject toolTipInstance = null;

        protected override void SetCardViewEvent(ObservableEventTrigger observableEvent)
        {
            base.SetCardViewEvent(observableEvent);

            observableEvent
                .OnPointerEnterAsObservable()
                .Subscribe(_ =>
                {
                    if (toolTipInstance == null)
                    {
                        toolTipInstance = Instantiate<GameObject>(toolTipPrefab);
                        toolTipInstance.transform.SetParent(observableEvent.gameObject.transform);
                        toolTipInstance.transform.localPosition = new Vector3(0, 120, 0);
                        toolTipInstance.GetComponentInChildren<TMPro.TextMeshProUGUI>().text =
                            playerData.CardManager.GetCardData(
                                playerData.CardManager.containers[(int)type]
                                .GetAt(observableEvent.gameObject.transform.GetSiblingIndex())).CardName;
                    }
                }).AddTo(this);

            observableEvent
                .OnPointerExitAsObservable()
                .Subscribe(_ =>
                {
                    if (toolTipInstance == null) return;
                    Destroy(toolTipInstance);
                    toolTipInstance = null;
                   
                }).AddTo(this);
        }
    }
}

