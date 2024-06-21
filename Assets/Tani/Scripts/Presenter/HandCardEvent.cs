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
                if (data.CardManager.Hand.UseCardEnable)
                {
                    data.CardManager.Hand.UseCard(transform.GetSiblingIndex());

                }
            }).AddTo(this);


        
    }

    private void OnDestroy()
    {

    }

  
}
