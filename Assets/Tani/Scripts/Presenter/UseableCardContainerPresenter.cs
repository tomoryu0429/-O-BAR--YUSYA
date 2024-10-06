using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using System;
using R3.Triggers;

[RequireComponent(typeof(CardContainerPresenter))]
public class UseableCardContainerPresenter : MonoBehaviour
{
    [SerializeField] private UIControls.CardUseMenu menu;

    public Observable<IndexIdPair> OnCardUseSelected => _onCardUseSelected;

    private Subject<IndexIdPair> _onCardUseSelected = new();
    private void Start()
    {
        var presenter = GetComponent<CardContainerPresenter>();

        presenter.OnCardCreated
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

        menu.OnCardUseSelected.Subscribe(info=>_onCardUseSelected.OnNext(info)).AddTo(this);
    }
}
