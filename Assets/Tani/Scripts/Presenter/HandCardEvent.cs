using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;
using Alchemy.Inspector;
using TMPro;


/// <summary>
/// 名前不適合,すべてのカードのイベントを管理するクラス
/// </summary>
public class HandCardEvent : MonoBehaviour
{
    [field: SerializeField]
    ObservableEventTrigger ObservableEvent;

    [SerializeField]
    [AssetsOnly]
    GameObject DiscriptionPrefab;

    [SerializeField]
    EPileType type;


    PlayerData data;
    GameObject discriptionInstance = null;
    enum EPileType
    {
        Hand,Draw,Discard
    }
    private void Awake()
    {
        data = PlayerData.Instance;

        this.ObservableEvent
            .OnPointerEnterAsObservable()
            .Subscribe(_ =>
            {
                if (discriptionInstance != null) return;
                transform.localScale = new Vector3(1.2f,1.2f, 0);

                var go = Instantiate<GameObject>(DiscriptionPrefab, transform);
                discriptionInstance = go;
                go.transform.localPosition = new Vector3(0, 150, 0);
                var tmp = go.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                tmp.text = data.CardManager.GetCardData(
                    type switch
                    {
                        EPileType.Hand => data.CardManager.Hand.GetAt(transform.GetSiblingIndex()),
                        EPileType.Draw => data.CardManager.Draw.GetAt(transform.GetSiblingIndex()),
                        EPileType.Discard => data.CardManager.Discard.GetAt(transform.GetSiblingIndex()),
                        
                    }).CardName;
            }).AddTo(this);

        this.ObservableEvent
            .OnPointerExitAsObservable()
            .Subscribe(_ =>
            {
                transform.localScale = Vector3.one;
                Destroy(discriptionInstance);
                discriptionInstance = null;
            }).AddTo(this);

        this.ObservableEvent
            .OnPointerClickAsObservable()
            .Where(_=>type == EPileType.Hand)
            .Subscribe(_ =>
            {
                switch (type)
                {
                    case EPileType.Hand:
                        data.CardManager.Hand.UseCard(transform.GetSiblingIndex());
                        break;
                    case EPileType.Draw:
                        data.CardManager.Draw.UseCard(transform.GetSiblingIndex());
                        break;
                    case EPileType.Discard:
                        data.CardManager.Discard.UseCard(transform.GetSiblingIndex());
                        break;
                }
            }).AddTo(this);
        Tani.TurnController.OnTurnStart += this.OnTurnStart;
        Tani.TurnController.OnTurnEnd += this.OnTurnEnd;
        
    }

    private void OnDestroy()
    {
        Tani.TurnController.OnTurnStart -= this.OnTurnStart;
        Tani.TurnController.OnTurnEnd -= this.OnTurnEnd;
    }

    void OnTurnStart(Tani.TurnController.ETurn eTurn)
    {
        switch (type)
        {
            case EPileType.Hand:
                switch (eTurn)
                {
                    case Tani.TurnController.ETurn.Invalid:
                        break;
                    case Tani.TurnController.ETurn.CardTurn:

                        this.ObservableEvent.enabled = true;
                        break;
                    case Tani.TurnController.ETurn.YusyaTurn:
                        break;
                    case Tani.TurnController.ETurn.EnemyTurn:
                        break;
                }

                break;
            case EPileType.Draw:
                break;
            case EPileType.Discard:
                break;
        }

    }
    void OnTurnEnd(Tani.TurnController.ETurn eTurn)
    {
        switch (type)
        {
            case EPileType.Hand:
                switch (eTurn)
                {
                    case Tani.TurnController.ETurn.Invalid:
                        break;
                    case Tani.TurnController.ETurn.CardTurn:
                        this.ObservableEvent.enabled = false;
                        transform.localScale = Vector3.one;
                        if (discriptionInstance)
                        {
                            Destroy(discriptionInstance);
                            discriptionInstance = null;
                        }
                        break;
                    case Tani.TurnController.ETurn.YusyaTurn:
                        break;
                    case Tani.TurnController.ETurn.EnemyTurn:
                        break;
                }
                break;
            case EPileType.Draw:
                break;
            case EPileType.Discard:
                break;
        }

    }
}
