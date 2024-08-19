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
    
    
    public class CardManager : MonoBehaviour
    {
        public enum EPileType
        {
            Invalid = -1,Hand,Draw,Discard,Max
        }


        public CardContainer[] containers = new CardContainer[(int)EPileType.Max];
        public UniTaskCompletionSource CS_Init = new UniTaskCompletionSource();
        Dictionary<AutoEnum.ECardID, CardData> cardDatas = new();


        private  void Awake()
        {

            containers[0] = new CardContainer();
            containers[1] = new CardContainer();
            containers[2] = new CardContainer();

            //手札が使用されたとき使用された手札と残りの手札は墓地に送られる
            containers[(int)EPileType.Hand].OnCardUsed
                .AsObservable()
                .Subscribe(arg => {

                    containers[(int)EPileType.Discard].AddCard(arg.Arg1);

                    CardContainer handContainer = containers[(int)CardManager.EPileType.Hand];
                    foreach (var n in handContainer.GetAllCards())
                    {
                       containers[(int)EPileType.Discard].AddCard(n);
                    }
                    handContainer.ClearCards();

                })
                .AddTo(this);


            

          
        }

        public void DrawCard()
        {
            var drawPile = containers[(int)EPileType.Draw];
            var handPile = containers[(int)EPileType.Hand];
            var discardPile = containers[(int)EPileType.Discard];


            var getData = drawPile.GetRandom();
            if (getData.HasValue)
            {
                drawPile.Remove(getData.Value.Item2);
                handPile.AddCard(getData.Value.Item1);
            }
            else
            {
                int count = discardPile.Count;
                for(int i = 0; i < count; i++)
                {
                    var id = discardPile.GetAt(0);
                    discardPile.Remove(0);
                    drawPile.AddCard(id);
                }
                getData = drawPile.GetRandom();
                if (getData.HasValue)
                {
                    drawPile.Remove(getData.Value.Item2);
                    handPile.AddCard(getData.Value.Item1);
                }

            }
        }

        public List<AutoEnum.ECardID> GetSortedAllCardList()
        {
            var all = containers.SelectMany((container) => container.GetAllCards());

            List<AutoEnum.ECardID> sortedList = new List<AutoEnum.ECardID>();
            for(int i = 0;i < (int)AutoEnum.ECardID.Max; i++)
            {
                sortedList.AddRange(all.Where(id => id == (AutoEnum.ECardID)i));
            }
            return sortedList;
        }



        [Obsolete]
        public CardData GetCardData(AutoEnum.ECardID id)
        {
            throw new NotImplementedException();
            return cardDatas[id];
        }

      


    }
}


