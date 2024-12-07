using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
using Cysharp.Threading.Tasks;
using R3;
using System;

namespace Tani
{
    /// <summary>
    /// プレイヤー用のカードコンテイナーを管理するWrapperクラス
    /// </summary>
    
    
    public class PlayerCardManager
    {

        public CardContainer HandCardContainer { get; }
        public CardContainer DiscardCardContainer { get; }
        public CardContainer DrawpileCardContainer { get; }

        private PlayerStatus Status { get; }

        private float _cardEffectMultiply = 1f;
        public PlayerCardManager(PlayerStatus playerStatus)
        {

            HandCardContainer = new CardContainer();
            DiscardCardContainer = new CardContainer();
            DrawpileCardContainer = new CardContainer();
            Status = playerStatus;

        }


        public  void UseCard(CardContainer container,int index)
        {
            AutoEnum.ECardID item = container[index];
            container.MoveCardToAnotherContainer(index, DiscardCardContainer);
            //カードの効果を発動する
            Debug.Log($"{CardSystem.Utility.GetCardData(item).CardName}を使用");
            ApplyCardEffect(item);
            Status.RemainingUseCount.Value--;
            

        }

        public void MoveHandCardContainerCardToDiscardContainer()
        {
            DiscardCardContainer.Add(HandCardContainer);
            HandCardContainer.Clear();
        }

        //山札から一枚引き、手札に移動
        public void DrawCard()
        {

            IndexIdPair drawedData = DrawpileCardContainer.GetRandom();

            if (drawedData != null)//DrawPileにカードが存在している
            {
                DrawpileCardContainer.MoveCardToAnotherContainer(drawedData.index, HandCardContainer);
            }
            else//Drawpileにカードが存在しないためDiscardPileから持ってきて、引く
            {
                DrawpileCardContainer.Add(DiscardCardContainer);
                DiscardCardContainer.Clear();
                if(DrawpileCardContainer.Count == 0) { throw new Exception("カードが存在しません"); }
                DrawCard();

            }
        }

        public List<AutoEnum.ECardID> GetSortedAllCardList()
        {
            var all = HandCardContainer
                .Concat( DiscardCardContainer)
                .Concat(DrawpileCardContainer);

            List<AutoEnum.ECardID> sortedList = new List<AutoEnum.ECardID>();
            for(int i = 0;i < (int)AutoEnum.ECardID.Max; i++)
            {
                sortedList.AddRange(all.Where(id => id == (AutoEnum.ECardID)i));
            }
            return sortedList;
        }



        private void ApplyCardEffect(AutoEnum.ECardID id)
        {
            var data = CardSystem.Utility.GetCardData(id);
            foreach(var card in data.Effects)
            {
                card?.ApplyEffect(Status);
                Debug.Log($"カード効果 : {card?.EffectLabel},値 : {card?.ChangeValue}");
            }
        }
    }
}


