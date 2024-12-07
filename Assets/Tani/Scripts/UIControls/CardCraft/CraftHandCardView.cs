using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
public class CraftHandCardView : MonoBehaviour, IPlacable
{
    [SerializeField] private GameObject _draggableCardViewPrefab;

    private CardContainer container;

    public void Entry()
    {
        container = PlayerData.Instance.CardManager.HandCardContainer;

        container.OnCardAddedAsObservable.Subscribe(_ => ReInitialize()).AddTo(this);
        container.OnCardRemovedAsObservable.Subscribe(_ => ReInitialize()).AddTo(this);

        ReInitialize();

    }

    private void OnEnable()
    {
        ReInitialize();
    }

    public void ReInitialize()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        foreach(var id in container)
        {
            Instantiate(_draggableCardViewPrefab,transform).GetComponentInChildren<Tani.CardView>().DefineCardData(id);
        }
    }

    public RectTransform GetTransform()
    {
        return (RectTransform)transform;
    }

    public void OnAway(GameObject exit)
    {
        
    }

    public void OnPlace(GameObject drop)
    {
        
    }
}
