using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using UnityEngine.Events;

public abstract class CardContainer 
{
    public int Count => cards.Count;
    /// <summary>
    /// �����̓��X�g�̃C���f�b�N�X
    /// </summary>
    public event UnityAction<int> OnCardAdded;
    /// <summary>
    /// �����̓��X�g�̃C���f�b�N�X
    /// </summary>
    public event UnityAction<int> OnCardRemoved;
    public CardManager CardManager { get; }

    protected List<CardData.ECardID> cards = new();

    public CardContainer(CardManager cardManager)
    {
        CardManager = cardManager;
    }

    public void AddCard(CardData.ECardID id)
    {
        cards.Add(id);
        OnCardAdded.Invoke(Count);
    }
    public void Remove(int listIndex)
    {
        if(listIndex >= Count)
        {
            Debug.LogError("indexOutOfRange");
            return;
        }
        cards.RemoveAt(listIndex);
        OnCardRemoved.Invoke(listIndex);
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

   

}

public class DrawPile : CardContainer
{
    public DrawPile(CardManager cardManager) : base(cardManager)
    {

    }
}

public class HandPile : CardContainer
{
    public HandPile(CardManager cardManager) : base(cardManager)
    {

    }

    public void Shuffle()
    {
        if (Count <= 1) return;
        System.Random random = new System.Random();
        int n = Count;
        while(n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var tmp = cards[k];
            cards[k] = cards[n];
            cards[n] = tmp;
        }
    }
}

public class DiscardPile : CardContainer
{
    public DiscardPile(CardManager cardManager) : base(cardManager)
    {

    }
}
