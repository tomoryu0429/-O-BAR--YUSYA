using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;

namespace Tani
{
    public class CardViewGenerator : MonoBehaviour
    {
        [SerializeField]
        Transform card_parent;
        [SerializeField,AssetsOnly]
        GameObject card_prefab;
        [SerializeField,LabelText("参照するコンテナのタイプ")]
        CardManager.EPileType type = CardManager.EPileType.Invalid;

        public void Init()
        {
            //子オブジェクトをすべて破棄
            if (gameObject.transform.childCount != 0)
            {
                Transform[] childs = new Transform[gameObject.transform.childCount];
                for (int i = 0; i < childs.Length; i++)
                {
                    childs[i] = transform.GetChild(i);
                }

                foreach (var n in childs)
                {
                    Destroy(n.gameObject);
                }
            }



            foreach (var n in PlayerData.Instance.CardManager.containers[(int)type].GetAllCards())
            {
                var go = Instantiate<GameObject>(card_prefab, card_parent);
                CardView cardView = go.GetComponent<CardView>();
                cardView.Sprite = PlayerData.Instance.CardManager.GetCardData(n).CardSprite;
                cardView.Init(type, PlayerData.Instance.CardManager.GetCardData(n));
             

            }
        }
        public void AddCard(int siblingIndex, Tani.CardData cardData)
        {
            var go = Instantiate<GameObject>(card_prefab, card_parent);
            CardView cardView = go.GetComponent<CardView>();
            cardView.Sprite = cardData.CardSprite;
            cardView.Init(type, cardData);


            go.transform.SetSiblingIndex(siblingIndex);
        }
        public void RemoveCard(int sibilingIndex)
        {

            DestroyImmediate(transform.GetChild(sibilingIndex).gameObject);
        }
    }
}

