using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using UnityEngine.Events;

public abstract class CardContainer 
{
    public int Count => cards.Count;
    /// <summary>
    /// 引数はリストのインデックス
    /// </summary>
    public event UnityAction<int> OnCardAdded;
    /// <summary>
    /// 引数はリストのインデックス
    /// </summary>
    public event UnityAction<int> OnCardRemoved;
    public Tani.CardManager CardManager { get; }

    protected List<CardData.ECardID> cards = new();

    public CardContainer(Tani.CardManager cardManager)
    {
        CardManager = cardManager;
    }

    public void AddCard(CardData.ECardID id)
    {
        cards.Add(id);
        OnCardAdded.Invoke(Count);
    }
    public bool Remove(int listIndex)
    {
        if(listIndex >= Count)
        {
            Debug.LogError("indexOutOfRange");
            return false;
        }
        cards.RemoveAt(listIndex);
        OnCardRemoved.Invoke(listIndex);
        return true;
    }
    public bool Remove(CardData.ECardID id)
    {
        if (cards.Contains(id))
        {
            cards.Remove(id);
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



}

public class DrawPile : CardContainer
{
    public DrawPile(Tani.CardManager cardManager) : base(cardManager)
    {

    }
}

public class HandPile : CardContainer
{
    public HandPile(Tani.CardManager cardManager) : base(cardManager)
    {

    }


}

public class DiscardPile : CardContainer
{
    public DiscardPile(Tani.CardManager cardManager) : base(cardManager)
    {

    }
}
