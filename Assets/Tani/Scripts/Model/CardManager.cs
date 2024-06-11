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
            drawPile = new DrawPile(this);
            handPile = new HandPile(this);
            discardPile = new DiscardPile(this);
            foreach(var n in AllCards)
            {
                cardDatas.Add(n.CardID, n);
            }
        }

        public CardData GetCardData(CardData.ECardID id) => cardDatas[id]; 

        Dictionary<CardData.ECardID, CardData> cardDatas = new();

        PlayerData owner = null;
        DrawPile drawPile;
        HandPile handPile;
        DiscardPile discardPile;

    }
}


