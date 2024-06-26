using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using System;

namespace Tani
{
    public class CardViewGenerator : MonoBehaviour
    {
        [SerializeField]
        protected PlayerData playerData;


        [SerializeField]
        Transform card_parent;
        [SerializeField,AssetsOnly]
        GameObject card_prefab;
        [SerializeField,LabelText("参照するコンテナのタイプ")]
        CardManager.EPileType type = CardManager.EPileType.Invalid;

        public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();

        private async void Start()
        {

            await playerData.CS_Init.Task;
            Init();
        }

        public void Init()
        {
            //子オブジェクトをすべて破棄
            if (card_parent.childCount != 0)
            {
                Transform[] childs = new Transform[card_parent.childCount];
                for (int i = 0; i < childs.Length; i++)
                {
                    childs[i] = card_parent.GetChild(i);
                }

                foreach (var n in childs)
                {
                    Destroy(n.gameObject);
                }
            }

           

            foreach (var n in playerData.CardManager.containers[(int)type].GetAllCards())
            {
                var go = Instantiate<GameObject>(card_prefab, card_parent);
                CardView cardView = go.GetComponent<CardView>();
                cardView.Sprite = playerData.CardManager.GetCardData(n).CardSprite;
              
             

            }

            playerData.CardManager.containers[(int)type].OnCardAdded += AddCard;
            playerData.CardManager.containers[(int)type].OnCardRemoved += RemoveCard;

            //初期化終了
            CS_Init.TrySetResult();
        }

        private void OnDestroy()
        {
            playerData.CardManager.containers[(int)type].OnCardAdded -= AddCard;
            playerData.CardManager.containers[(int)type].OnCardRemoved -= RemoveCard;
        }
        public void AddCard(int siblingIndex, Tani.CardData.ECardID id)
        {
            Tani.CardData cardData = playerData.CardManager.GetCardData(id);

            var go = Instantiate<GameObject>(card_prefab, card_parent);
            CardView cardView = go.GetComponent<CardView>();
            cardView.Sprite = cardData.CardSprite;
            SetCardViewEvent(cardView.ObservableEvent);


            go.transform.SetSiblingIndex(siblingIndex);
        }

     

        public void RemoveCard(int sibilingIndex,CardData.ECardID iD)
        {

            DestroyImmediate(card_parent.GetChild(sibilingIndex).gameObject);
        }

        protected virtual void SetCardViewEvent(ObservableEventTrigger observableEvent)
        {
            observableEvent
                .OnPointerEnterAsObservable()
                .Subscribe(_ =>
                {
                    //カードを拡大
                    observableEvent.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 0);
                    //observableEvent.gameObject.transform.localPosition = new Vector3(0, 150, 0);
                }).AddTo(this);

            observableEvent
               .OnPointerExitAsObservable()
               .Subscribe(_ =>
               {
                   //カードを拡大
                   observableEvent.gameObject.transform.localScale = Vector3.one;
                   //observableEvent.gameObject.transform.localPosition = Vector3.zero;
               }).AddTo(this);
        }

    }
}

