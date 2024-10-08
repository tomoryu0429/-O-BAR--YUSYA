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


        [SerializeReference] public List<CardSystem.ICardEffect> __effects;

        [SerializeField, SerializeReference] private List<CardSystem.ICardEffect> _list;



        public ECardID CardID => cardID;
        public string CardName => cardName;
        public ECardKinds CardKind => kind;
        public ECardTaste CardTaste => taste;
        public int BuyPrice => buyPrice;
        public int SellOPrice => sellPrice;
        public Sprite CardSprite => cardSprite;
        public IReadOnlyList<CardSystem.ICardEffect> Effects => __effects;

        public enum ECardKinds
        {
            None,Meet_Fish,Vegetable,RowFood,Sweety,BigPlate,Dessert
        }
        public enum ECardTaste
        {
            None,Syoppai,Amai
        }
        
    }
}


