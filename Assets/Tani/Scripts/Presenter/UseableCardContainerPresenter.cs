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

    public Observable<(int index, AutoEnum.ECardID id)> OnCardUseSelected => _onCardUseSelected;

    private Subject<(int index, AutoEnum.ECardID id)> _onCardUseSelected = new();
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
                    menu.DefineCardInfo(go.transform.GetSiblingIndex(),go.GetComponent<Tani.CardView>().ID);

                }).AddTo(go);



            }).AddTo(this);

        menu.OnCardUseSelected.Subscribe(info=>_onCardUseSelected.OnNext(info)).AddTo(this);
    }
}
