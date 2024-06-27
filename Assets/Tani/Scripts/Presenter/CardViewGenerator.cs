using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using Cysharp.Threading.Tasks;
using R3;
using R3.Triggers;
using System;
using System.Linq;

namespace Tani
{
    public class CardViewGenerator : MonoBehaviour,IVisibilityControllable
    {
        [SerializeField]
        protected PlayerData playerData;
        [SerializeField]
        GameObject visibilityRoot;

        [SerializeField]
        protected Transform card_parent;
        [SerializeField,AssetsOnly]
        GameObject card_prefab;
        [SerializeField,LabelText("参照するコンテナのタイプ")]
        protected CardManager.EPileType type = CardManager.EPileType.Invalid;

        public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();
        private List<GameObject> cardsList = new();

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


            cardsList.Clear();
            foreach (var n in playerData.CardManager.containers[(int)type].GetAllCards())
            {
                var go = Instantiate<GameObject>(card_prefab, card_parent);
        
                cardsList.Add(go);
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
            if(siblingIndex >= cardsList.Count)
            {
                cardsList.Add(go);
            }
            else
            {
                cardsList.Insert(siblingIndex, go);

            }
            CardView cardView = go.GetComponent<CardView>();
            cardView.Sprite = cardData.CardSprite;
            SetCardViewEvent(cardView.ObservableEvent);


            go.transform.SetSiblingIndex(siblingIndex);
        }

     
        
        public void RemoveCard(int sibilingIndex,CardData.ECardID iD)
        {
            print($"type : {type},index : {sibilingIndex}, id : {iD} ");
            print($"list Count : {cardsList.Count}");
            DestroyImmediate(cardsList[sibilingIndex]);
            cardsList.RemoveAt(sibilingIndex);
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

        public void SetVisible(bool visibility)
        {
            visibilityRoot.SetActive(visibility);
        }

        public void SwitchVisibility()
        {
            visibilityRoot.SetActive(!visibilityRoot.activeSelf);
        }
    }
}

