using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using UnityEngine.Events;

public abstract class CardContainer 
{
    public int Count => cards.Count;
    /// <summary>
    /// 引数はリストの要素がaddされた要素のindex,id
    /// </summary>
    public event UnityAction<int,CardData.ECardID> OnCardAdded;
    /// <summary>
    /// 引数はリストの要素がaddされた要素のindex,id
    /// </summary>
    public event UnityAction<int, CardData.ECardID> OnCardRemoved;

    protected List<CardData.ECardID> cards = new();



    public void AddCard(CardData.ECardID id)
    {
        var index = GetContainerSibiling(id);
        if (index.HasValue)
        {
            cards.Insert(index.Value, id);
            OnCardAdded(index.Value, id);
        }
        else
        {
            cards.Add(id);
            OnCardAdded.Invoke(Count,id);
        }
        
        
    }
    public bool Remove(int listIndex)
    {
        if(listIndex >= Count)
        {
            Debug.LogError("indexOutOfRange");
            return false;
        }
        var removed_id = cards[listIndex];
        cards.RemoveAt(listIndex);
        OnCardRemoved.Invoke(listIndex,removed_id);
        return true;
    }
    public bool Remove(CardData.ECardID id)
    {
        if (cards.Contains(id))
        {
            int index = cards.IndexOf(id);
            cards.RemoveAt(index);
            OnCardRemoved.Invoke(index, id);

            return true;
        }
        else
        {
            return false;
        }
        
    }
    public bool Contains(CardData.ECardID id)
    {
        return cards.Contains(id);
    }
    public CardData.ECardID GetAt(int index)
    {
        if (index >= Count)
        {
            Debug.LogError("indexOutOfRange");
            return CardData.ECardID.Meet;
        }
        return cards[index];
    }

    public IEnumerable<CardData.ECardID> GetAllCards => cards;

    public void Shuffle()
    {
        if (Count <= 1) return;
        System.Random random = new System.Random();
        int n = Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var tmp = cards[k];
            cards[k] = cards[n];
            cards[n] = tmp;
        }
    }
    int? GetContainerSibiling(CardData.ECardID id)
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


}

public class DrawPile : CardContainer
{

}

public class HandPile : CardContainer
{



}

public class DiscardPile : CardContainer
{

}
