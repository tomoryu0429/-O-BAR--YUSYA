using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alchemy.Inspector;
namespace Tani
{
    public class CardContainerView : MonoBehaviour
    {
        [SerializeField]
        [LabelText("カードプレハブ")]
        [AssetsOnly]
        GameObject CardImageObj_Prefab;

        public void AddCard(int siblingIndex,Tani.CardData cardData)
        {
            var obj = Instantiate<GameObject>(CardImageObj_Prefab, transform);
            obj.gameObject.name = cardData.name;
            Tani.NormalImage cardImage = obj.GetComponent<Tani.NormalImage>();
            cardImage.Sprite = cardData.CardSprite;


            obj.transform.SetSiblingIndex(siblingIndex);
        }
        public void RemoveCard(int sibilingIndex)
        {
          
            DestroyImmediate(transform.GetChild(sibilingIndex).gameObject);
        }
    }
}