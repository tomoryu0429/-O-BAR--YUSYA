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
        }

        public CardData GetCardData(CardData.ECardID id) => cardDatas[id]; 

        Dictionary<CardData.ECardID, CardData> cardDatas = new();

        PlayerData owner = null;
        DrawPile drawPile = new DrawPile();
        HandPile handPile = new();
        DiscardPile discardPile = new DiscardPile();


    }
}


