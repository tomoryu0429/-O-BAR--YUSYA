using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tani
{
    public class CardImage : MonoBehaviour
    {
        [SerializeField]
        Image image;

        public Tani.CardData.ECardID CurrentID => currentId;
        private Tani.CardData.ECardID currentId;
        public void SetCardImage(Tani.CardData cardData)
        {
            image.sprite = cardData.CardSprite;
            currentId = cardData.CardID;
        }
    }
}

