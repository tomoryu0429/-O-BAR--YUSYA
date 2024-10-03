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

        public int RemainingUseCount { get;  set; } = 1;

        public PlayerCardManager()
        {

            HandCardContainer = new CardContainer();
            DiscardCardContainer = new CardContainer();
            DrawpileCardContainer = new CardContainer();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="index"></param>
        /// <returns>これ以上カードを使用できなければtrue</returns>
        public  bool UseCard(CardContainer container,int index)
        {
            AutoEnum.ECardID item = container[index];
            container.MoveCardToAnotherContainer(index, DiscardCardContainer);
            //カードの効果を発動する

            RemainingUseCount--;
            if(RemainingUseCount > 0)
            { 
                return false;
            }
            else
            {
                DiscardCardContainer.Add(container);
                container.Clear();
                return true;
            }
            

        }

        //山札から一枚引き、手札に移動
        public void DrawCard()
        {

            (AutoEnum.ECardID item, int index)? drawedData = DrawpileCardContainer.GetRandom();

            if (drawedData.HasValue)//DrawPileにカードが存在している
            {
                DrawpileCardContainer.MoveCardToAnotherContainer(drawedData.Value.index, HandCardContainer);
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

        public void ResetRemainingUseCount() => RemainingUseCount = 1;

    }
}


