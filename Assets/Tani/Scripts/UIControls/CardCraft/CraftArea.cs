using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tani;
public class CraftArea : MonoBehaviour, IPlacable
{
    [SerializeField] private CraftCardOutputView outPutImage;

    public ReadOnlyReactiveProperty<bool> IsCraftable => _isCraftable.ToReadOnlyReactiveProperty();
    private ReactiveProperty<bool> _isCraftable = new(false);

    public void CalcCraftCard()
    {
        int totalPrimeNumberProduct = 1;

        for (int i = 0; i < transform.childCount; i++)
        {
            totalPrimeNumberProduct *= 
                CardSystem.Utility.GetCardIdPrimeNumber(transform.GetChild(i).gameObject.GetComponent<CardView>().ID);
        }

        var craftCardId = CardSystem.Utility.GetCraftableCardId(totalPrimeNumberProduct);

        _isCraftable.Value = craftCardId != AutoEnum.ECardID.Invalid;

        outPutImage.SetCardPreview(craftCardId);
    }

    public void PerformCraft()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        _isCraftable.Value = false;
    }
    

    public RectTransform GetTransform()
    {
        return (RectTransform)transform;
    }

    public void OnAway(GameObject exit)
    {
        CalcCraftCard();
    }

    public void OnPlace(GameObject drop)
    {
        CalcCraftCard();
    }


}
