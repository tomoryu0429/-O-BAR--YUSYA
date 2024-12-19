using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using R3.Triggers;
using Alchemy.Inspector;
using UnityEngine.UI;
namespace Tani
{
    public class CardView : MonoBehaviour
    {

        public ObservableEventTrigger ObservableEvent;
        [SerializeField] Image _image;

        [ReadOnly]
        [field:SerializeField] public AutoEnum.ECardID ID{get;private set;}
       public void DefineCardData(AutoEnum.ECardID id)
        {
            this.ID = id;
            _image.sprite = CardSystem.Utility.GetCardData(id).CardSprite;
        }
    }
}

