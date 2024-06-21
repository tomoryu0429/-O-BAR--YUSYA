using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
namespace Tani
{
    public class CardManager : MonoBehaviour
    {
        [DisableInPlayMode]
        [Header("�Ǘ�����S��ނ̃J�[�h")]
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
                Debug.LogError("CardData�����݂��܂���");
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

        public List<CardData.ECardID> GetSortedAllCardList()
        {
            
            var hand = Hand.GetAllCards;
            var draw = Draw.GetAllCards;
            var discard = Discard.GetAllCards;

            var all = hand.Concat(draw).Concat(discard);

            List<CardData.ECardID> sortedList = new List<CardData.ECardID>();
            for(int i = 0;i < (int)CardData.ECardID.Max; i++)
            {
                sortedList.AddRange(all.Where(id => id == (CardData.ECardID)i));
            }
            return sortedList;
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


