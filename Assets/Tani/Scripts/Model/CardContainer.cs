using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using UnityEngine.Events;


/// <summary>
/// Card(CardId)をリストとして格納するためのWrapperクラス
/// リストに要素が追加されたときなどのコールバッグが存在
/// </summary>
public  class CardContainer 
{
    public int Count => cards.Count;
    /// <summary>
    /// 引数はリストの要素がaddされた要素のindex,id
    /// </summary>
    public  UnityEvent<int,AutoEnum.ECardID> OnCardAdded = new();
    /// <summary>
    /// 引数はリストの要素がRemoveされた要素のindex,id
    /// </summary>
    public  UnityEvent<int, AutoEnum.ECardID> OnCardRemoved = new();
    /// <summary>
    /// 引数はリストの要素がRemoveされた要素のindex,id
    /// </summary>
    public  UnityEvent<int, AutoEnum.ECardID> OnCardUsed = new();

    protected List<AutoEnum.ECardID> cards = new();

    

    public void AddCard(AutoEnum.ECardID id)
    {
        var index = GetContainerSibiling(id);
        if (index.HasValue)
        {
            cards.Insert(index.Value, id);
            OnCardAdded?.Invoke(index.Value, id);
        }
        else
        {
            cards.Add(id);
            OnCardAdded?.Invoke(Count,id);
        }
        
        
    }
    public bool Remove(int listIndex)
    {
        if(listIndex >= Count)
        {
            Debug.LogError($"indexOutOfRange : {Count}");
            return false;
        }
        var removed_id = cards[listIndex];
        cards.RemoveAt(listIndex);
        OnCardRemoved?.Invoke(listIndex,removed_id);
        return true;
    }
    public bool Remove(AutoEnum.ECardID id)
    {
        if (cards.Contains(id))
        {
            int index = cards.IndexOf(id);
            cards.RemoveAt(index);
            OnCardRemoved?.Invoke(index, id);

            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void UseCard(int index)
    {
        var id = cards[index];
        Remove(index);
        OnCardUsed?.Invoke(index, id);
        
    }
    public bool Contains(AutoEnum.ECardID id)
    {
        return cards.Contains(id);
    }
    public AutoEnum.ECardID GetAt(int index)
    {
        if (index >= Count)
        {
            Debug.LogError($"indexOutOfRange : {index}");
            return AutoEnum.ECardID.Invalid;
        }
        return cards[index];
    }
    public (AutoEnum.ECardID,int)? GetRandom()
    {
        if (Count == 0) return null;
        int index = Random.Range(0, cards.Count);
        AutoEnum.ECardID id = cards[index];
        return (id, index);
    }
    public void ClearCards()
    {
        int count = cards.Count;
        for(int i = 0; i < count; i++)
        {
            Remove(0);
        }
       
    }

    public IEnumerable<AutoEnum.ECardID> GetAllCards() => cards;

    int? GetContainerSibiling(AutoEnum.ECardID id)
    {
        int? index = null;
        for (int i = 0; i < cards.Count; i++)
        {
            if ((int)id < (int)cards[i])
            {
                index = i;
                break;
            }
        }
        return index;
    }

    //このコンテナに存在するcardIndexのカードを他のコンテナに移動する
    public void MoveCardToAnotherContainer(int cardIndex,CardContainer anotherContainer)
    {
        var card = GetAt(cardIndex);
        Remove(cardIndex);
        anotherContainer.AddCard(card);
    }

}


