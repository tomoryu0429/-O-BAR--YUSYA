using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Tani
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/Create CardData")]
    public class CardData : ScriptableObject
    {


        public ECardID cardID;
        public string cardName = "";
        public ECardKinds kind = ECardKinds.None;
        public ECardTaste taste = ECardTaste.None;
        public int buyPrice = 0;
        public int sellPrice = 0;
        public Sprite cardSprite;

        [SerializeReference]
        public CardEffect cardEffect_1;
        [SerializeReference]
        public CardEffect cardEffect_2;
        [SerializeReference]
        public CardEffect cardEffect_3;

        public enum ECardKinds
        {
            None,Meet_Fish,Vegetable,RowFood,Sweety,BigPlate,Dessert
        }
        public enum ECardTaste
        {
            None,Syoppai,Amai
        }
        public enum ECardID
        {
            Meet,Fish,Mash,Tomato,Onion,Rice,Zer,Flour,Strawberry,Honey,Milk,Choco
        }
    }
}


