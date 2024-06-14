using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alchemy.Inspector;
namespace Tani 
{
    public class HorizontalCardContainer : MonoBehaviour
    {
        [SerializeField]
        [LabelText("カードプレハブ")]
        [AssetsOnly]
        GameObject CardImageObj_Prefab;

        List<Tani.CardImage> cardImagesDatas = new();

        public void AddCard(Tani.CardData cardData)
        {
            print("kokokara");
            foreach(var n in cardImagesDatas)
            {
                print(n.CurrentID);
            }
            print("kokomade");
            var obj = Instantiate<GameObject>(CardImageObj_Prefab, transform);
            obj.gameObject.name = cardData.name;
            Tani.CardImage cardImage = obj.GetComponent<Tani.CardImage>();
            cardImage.SetCardImage(cardData);
            int index = -1;
            for (int i = 0; i < cardImagesDatas.Count; i++)
            {
                if((int)cardData.CardID < (int)cardImagesDatas[i].CurrentID)
                {
                    index = i;
                    break;
                }
            }
            print($"index : {index}");
            if(index == -1)
                cardImagesDatas.Add(cardImage);
            else
                cardImagesDatas.Insert(index, cardImage);

            obj.transform.SetSiblingIndex(index);
        }
    }
}


