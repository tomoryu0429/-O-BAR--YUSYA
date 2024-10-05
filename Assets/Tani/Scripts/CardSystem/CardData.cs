using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoEnum;



namespace Tani
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/Create CardData")]
    public class CardData : ScriptableObject
    {

        [SerializeField]
        private ECardID cardID;
        [SerializeField]
        private string cardName = "";
        [SerializeField]
        private ECardKinds kind = ECardKinds.None;
        [SerializeField]
        private ECardTaste taste = ECardTaste.None;
        [SerializeField]
        private int buyPrice = 0;
        [SerializeField]
        private int sellPrice = 0;
        [SerializeField]
        private Sprite cardSprite;
        [SerializeField] private List<CardEffectType> effectType;

        [field:SerializeField] public int YP_Increase { get; private set; }
        [field: SerializeField] public int Def_Increase { get; private set; }


        public ECardID CardID => cardID;
        public string CardName => cardName;
        public ECardKinds CardKind => kind;
        public ECardTaste CardTaste => taste;
        public int BuyPrice => buyPrice;
        public int SellOPrice => sellPrice;
        public Sprite CardSprite => cardSprite;
        public IReadOnlyList<CardEffectType> EffectList => effectType;

        public enum ECardKinds
        {
            None,Meet_Fish,Vegetable,RowFood,Sweety,BigPlate,Dessert
        }
        public enum ECardTaste
        {
            None,Syoppai,Amai
        }
        
        public enum CardEffectType
        {
            MotivationIncreaseSmall,
            MotivationIncreaseMiddle,
            MotivationIncreaseLarge, 
            GuardIncreaseSmall,
            GuardIncreaseMiddle,
            GuardIncreaseLarge,
            CardEffectIncreaseSmall, 
            CardEffectIncreaseMiddle, 
            CardEffectIncreaseLarge,
            AddCardUsageCount

        }
    }
}


