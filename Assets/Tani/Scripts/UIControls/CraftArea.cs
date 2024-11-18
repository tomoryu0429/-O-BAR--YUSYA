using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftArea : MonoBehaviour, IDropReceivable
{
    [SerializeField] private Image outPutImage;
    private void Start()
    {
        Observable.EveryValueChanged(transform, t => t.childCount)
            .Subscribe(childCount =>
            {
                int totalPrimeNumberProduct = 1;

                for (int i = 0; i < childCount; i++)
                {
                    totalPrimeNumberProduct *= CardSystem.Utility.GetCardIdPrimeNumber(transform.GetChild(i).gameObject.GetComponent<CardIdData>().Id);
                }

                var id = CardSystem.Utility.GetCraftableCardId(totalPrimeNumberProduct);
                
                if(id == AutoEnum.ECardID.Invalid) {
                    outPutImage.sprite = null;
                    return;
                }

                Tani.CardData data = CardSystem.Utility.GetCardData(id);
                outPutImage.sprite = data.CardSprite;
            }).AddTo(this);

    }

    public RectTransform GetTransform()
    {
        return (RectTransform)transform;
    }

    public void OnDrop(GameObject drop)
    {
        
    }
}
