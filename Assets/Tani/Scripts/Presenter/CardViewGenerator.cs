//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Alchemy.Inspector;
//using Cysharp.Threading.Tasks;
//using R3;
//using R3.Triggers;
//using System;
//using System.Linq;

//namespace Tani
//{
//    public class CardViewGenerator : MonoBehaviour,IVisibilityControllable
//    {

       
//        [SerializeField]
//        GameObject visibilityRoot;

//        [SerializeField]
//        protected Transform cardsRoot;
//        [SerializeField,AssetsOnly]
//        GameObject card_prefab;
//        [SerializeField,LabelText("参照するコンテナのタイプ")]
//        protected EPileType type = EPileType.Invalid;


//        private List<GameObject> cardsList = new();
//        protected PlayerData playerData;

//        protected enum EPileType
//        {
//            Invalid = -1,Hand,Draw,Discard
//        }

//        protected virtual void Start()
//        {
//            playerData = PlayerData.Instance;
//            Init();
  
//        }


//        public void Init()
//        {
//            //子オブジェクトをすべて破棄
//            if (cardsRoot.childCount != 0)
//            {
//                foreach (Transform n in cardsRoot)
//                {
//                    Destroy(n.gameObject);
//                }
//            }


//            cardsList.Clear();
//            foreach (var n in playerData.CardManager.containers[(int)type].GetAllCards())
//            {
//                var go = Instantiate<GameObject>(card_prefab, cardsRoot);
        
//                cardsList.Add(go);
//                CardView cardView = go.GetComponent<CardView>();
//                cardView.Sprite = CardSystem.CardSystemUtility.GetCardData(n).CardSprite;
              
             

//            }

//            //CardContainerのイベントに登録
//            playerData.CardManager.containers[(int)type].OnCardAdded
//                .AsObservable()
//                .Subscribe((arg) => AddCard(arg.Arg0, arg.Arg1))
//                .AddTo(this);

//            playerData.CardManager.containers[(int)type].OnCardRemoved
//                 .AsObservable()
//                 .Subscribe((arg) => RemoveCard(arg.Arg0, arg.Arg1))
//                 .AddTo(this);

//        }

    
//        public void AddCard(int siblingIndex, AutoEnum.ECardID id)
//        {
//            Tani.CardData cardData = CardSystem.CardSystemUtility.GetCardData(id);

//            var go = Instantiate<GameObject>(card_prefab, cardsRoot);
//            if(siblingIndex >= cardsList.Count)
//            {
//                cardsList.Add(go);
//            }
//            else
//            {
//                cardsList.Insert(siblingIndex, go);

//            }
//            CardView cardView = go.GetComponent<CardView>();
//            cardView.Sprite = cardData.CardSprite;
//            SetCardViewEvent(cardView.ObservableEvent);


//            go.transform.SetSiblingIndex(siblingIndex);
//        }

     
        
//        public void RemoveCard(int sibilingIndex, AutoEnum.ECardID iD)
//        {
//            DestroyImmediate(cardsList[sibilingIndex]);
//            cardsList.RemoveAt(sibilingIndex);
//        }

//        protected virtual void SetCardViewEvent(ObservableEventTrigger observableEvent)
//        {
//            observableEvent
//                .OnPointerEnterAsObservable()
//                .Subscribe(_ =>
//                {
//                    //カードを拡大
//                    observableEvent.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 0);
//                    //observableEvent.gameObject.transform.localPosition = new Vector3(0, 150, 0);
//                }).AddTo(this);

//            observableEvent
//               .OnPointerExitAsObservable()
//               .Subscribe(_ =>
//               {
//                   //カードを拡大
//                   observableEvent.gameObject.transform.localScale = Vector3.one;
//                   //observableEvent.gameObject.transform.localPosition = Vector3.zero;
//               }).AddTo(this);
//        }

//        public void SetVisible(bool visibility)
//        {
//            visibilityRoot.SetActive(visibility);
//        }

//        public void SwitchVisibility()
//        {
//            visibilityRoot.SetActive(!visibilityRoot.activeSelf);
//        }
//    }
//}

