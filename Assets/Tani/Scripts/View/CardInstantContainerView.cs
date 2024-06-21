using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;

namespace Tani
{
    public class CardInstantContainerView : MonoBehaviour
    {
        [SerializeField]
        [LabelText("�J�[�h�v���n�u")]
        [AssetsOnly]
        GameObject CardImageObj_Prefab;
        [SerializeField]
        EPileType type;
        private void Awake()
        {
            IEnumerable<CardData.ECardID> list;
            //�������̉���
            list = PlayerData.Instance.CardManager.Draw.GetAllCards;
            switch (type)
            {
                case EPileType.Draw:
                    list = PlayerData.Instance.CardManager.Draw.GetAllCards;
                    break;
                case EPileType.Discard:
                    list = PlayerData.Instance.CardManager.Discard.GetAllCards;
                    break;
            }

           
            foreach(var n in list)
            {
                var go = Instantiate<GameObject>(CardImageObj_Prefab,this.gameObject.transform);
                NormalImage image = go.GetComponent<NormalImage>();
                image.Sprite = PlayerData.Instance.CardManager.GetCardData(n).CardSprite;
                HandCardEvent cardEvent = go.GetComponent<HandCardEvent>();
                
            }
        }

        private enum EPileType
        {
           Draw,Discard
        }
    }
}

