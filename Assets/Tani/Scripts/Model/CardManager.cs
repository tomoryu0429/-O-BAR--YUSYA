using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
namespace Tani
{
    public class CardManager : MonoBehaviour
    {
        [DisableInPlayMode]
        [Header("管理する全種類のカード")]
        [SerializeField]
        List<CardData> AllCards;

        public DrawPile Draw => drawPile;
        public HandPile Hand => handPile;
        public DiscardPile Discard => discardPile;
        PlayerData Owner {
            get => owner;
            set
            {
                if (!owner)
                {
                    owner = value;
                }
                else
                {
                    print("owner Player data already defined");
                }
            }
        }

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
            handPile.OnCardUsed += HandPileCardOnUsed;
        }

        public void DrawCard()
        {
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

        private void HandPileCardOnUsed (int index, CardData.ECardID id)
        {
            discardPile.AddCard(id);
        }

        public CardData GetCardData(CardData.ECardID id) => cardDatas[id]; 

        Dictionary<CardData.ECardID, CardData> cardDatas = new();

        PlayerData owner = null;
        DrawPile drawPile = new DrawPile();
        HandPile handPile = new();
        DiscardPile discardPile = new DiscardPile();


    }
}


