using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using System;
using R3.Triggers;

public class UseableCardContainerPresenter : UIGroup
{
    [SerializeField] private UIControls.CardUseMenu menu;
    [SerializeField] private CardContainerPresenter cardContainerPresenter;
    public Observable<IndexIdPair> OnCardUseSelected => _onCardUseSelected;

    private Subject<IndexIdPair> _onCardUseSelected = new();

    public override void Initialize()
    {
        menu.Entry();
        cardContainerPresenter.OnCardCreated
            .Subscribe(go =>
            {
                go.GetComponentInChildren<ObservableEventTrigger>()
                .OnPointerClickAsObservable()
                .Subscribe(_ =>
                {
                    menu.gameObject.SetActive(true);
                    menu.DefineCardInfo(new IndexIdPair { index = go.transform.GetSiblingIndex(), id = go.GetComponent<Tani.CardView>().ID });

                }).AddTo(go);



            }).AddTo(this);

        menu.OnCardUseSelected.Subscribe(info => _onCardUseSelected.OnNext(info)).AddTo(this);
    }
}
