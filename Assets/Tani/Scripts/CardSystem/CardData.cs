using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoEnum;
using Alchemy.Inspector;


namespace Tani
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/Create CardData")]
    public class CardData : ScriptableObject
    {        
        [field: SerializeField] public ECardID CardID { get; private set; }
        [field: SerializeField] public string CardName { get; private set; }
        [field: SerializeField] public ECardKinds CardKind { get; private set; }
        [field: SerializeField] public ECardTaste CardTaste { get; private set; }
        [field: SerializeField] public int BuyPrice { get; private set; }
        [field: SerializeField] public int SellOPrice { get; private set; }
        [field: SerializeField] public Sprite CardSprite { get; private set; }
        public IReadOnlyList<CardSystem.ICardEffect> Effects => _effects;
        public IReadOnlyList<ECardID> Ingredients => _ingredients;

        //カード効果
        [SerializeField, SerializeReference] private List<CardSystem.ICardEffect> _effects;

        //このカードを作成するのに必要な素材リスト
        [field: SerializeField] public bool Cookable { get; private set; } = false;
        [SerializeField, ShowIf(nameof(Cookable))] private List<ECardID> _ingredients;



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


