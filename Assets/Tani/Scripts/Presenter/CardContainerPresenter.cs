using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using R3.Triggers;
using Tani;

//CardContainerクラスを参照し、状態をViewに反映します
public class CardContainerPresenter : MonoBehaviour
{
    [SerializeField]private GameObject visibilityRoot;

    [SerializeField]private Transform cardsRoot;

    [AssetsOnly]
    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private EPileType type;

    public Observable<GameObject> OnCardCreated => _onCardCreated;

    private Subject<GameObject> _onCardCreated = new();

    private Stack<CardView> _objectPool = new();
    private List<CardView> _visibleObjects = new();

    private CompositeDisposable disposables = new();
    private void Start()
    {
        //子オブジェクトをすべて破棄
        if (cardsRoot.childCount != 0)
        {
            foreach (Transform n in cardsRoot)
            {
                Destroy(n.gameObject);
            }
        }
        SwitchVisibility();
        SwitchVisibility();
    }

    public void SetVisible(bool visibility)
    {
        visibilityRoot.SetActive(visibility);

        if (visibility) { CardsShown(); }
        else { CardsHidden(); }

    }

    public void CardsShown()
    {
        CardContainer container = type switch
        {
            EPileType.Invalid => throw new System.InvalidOperationException(),
            EPileType.Hand => PlayerData.Instance.CardManager.HandCardContainer,
            EPileType.Discard => PlayerData.Instance.CardManager.DiscardCardContainer,
            EPileType.Draw => PlayerData.Instance.CardManager.DrawpileCardContainer,
            _ => throw new System.InvalidOperationException()
        };


        for (int i = 0; i < container.Count; i++)
        {
            InitializeCardView(GetCardView(), i, container[i]);
        }

        container.OnCardAddedAsObservable
            .Subscribe(CardAdded)
            .AddTo(disposables);
        container.OnCardRemovedAsObservable
            .Subscribe(CardRemoved)
            .AddTo(disposables);
    }

    public void CardsHidden()
    {
        foreach(var cardView in _visibleObjects)
        {
            cardView.gameObject.SetActive(false);
            _objectPool.Push(cardView);
        }
        _visibleObjects.Clear();
        disposables.Clear();
    }

    private void CardAdded(IndexIdPair addedData)
    {
        InitializeCardView(GetCardView(), addedData.index, addedData.id);
    }

    private void CardRemoved(IndexIdPair removedData)
    {
        var cardView = _visibleObjects[removedData.index];
        cardView.gameObject.SetActive(false);
        cardView.gameObject.transform.SetAsLastSibling();
        _visibleObjects.RemoveAt(removedData.index);
        _objectPool.Push(cardView);

    }

    private void InitializeCardView(CardView cardView,int sibilingIndex,AutoEnum.ECardID id)
    {
        cardView.gameObject.SetActive(true);
        cardView.transform.SetSiblingIndex(sibilingIndex);
        cardView.DefineCardData(id);
        _visibleObjects.Add(cardView);
    }

    private CardView GetCardView()
    {
        //プールに存在する場合はそれを返却
        if(_objectPool.Count != 0){
            return _objectPool.Pop();
        }
        //存在しない場合は作成し、リストに登録
        GameObject go = Instantiate(cardPrefab, cardsRoot);
        _onCardCreated.OnNext(go);
        var cardView = go.GetComponentInChildren<CardView>();
        if(cardView == null) { throw new System.Exception("CardViewコンポーネントが存在しません"); }
        return cardView;
    }

    public void SwitchVisibility()
    {
        SetVisible(!visibilityRoot.activeSelf);
    }

    public enum EPileType
    {
        Invalid = -1,Hand,Discard,Draw
    }
}
