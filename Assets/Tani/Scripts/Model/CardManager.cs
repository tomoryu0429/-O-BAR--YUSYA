using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
namespace Tani
{
    /// <summary>
    /// プレイヤー用のカードコンテイナーを管理するWrapperクラス
    /// </summary>
    public class CardManager : MonoBehaviour
    {
        [DisableInPlayMode]
        [Header("管理する全種類のカード")]
        [SerializeField]
        List<CardData> AllCards;

        public bool CanCardUse { get;private set; } = false;

        public enum EPileType
        {
            Invalid = -1,Hand,Draw,Discard,Max
        }
        public CardContainer[] containers = new CardContainer[(int)EPileType.Max];

        private void Awake()
        {

            if(AllCards == null)
            {
                Debug.LogError("CardDataが存在しません");
                return;
            }
            foreach(var n in AllCards)
            {
                cardDatas.Add(n.CardID, n);
            }

            containers[0] = new CardContainer();
            containers[1] = new CardContainer();
            containers[2] = new CardContainer();
            containers[(int)EPileType.Hand].OnCardUsed += HandPileCardOnUsed;
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

        private void HandPileCardOnUsed (int index, AutoEnum.ECardID id)
        {
            containers[(int)EPileType.Discard].AddCard(id);
        }

        public CardData GetCardData(AutoEnum.ECardID id) => cardDatas[id]; 

        Dictionary<AutoEnum.ECardID, CardData> cardDatas = new();

        PlayerData owner = null;


    }
}


