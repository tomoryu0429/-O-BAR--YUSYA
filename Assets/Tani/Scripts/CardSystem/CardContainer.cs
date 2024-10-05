using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using UnityEngine.Events;
using AutoEnum;
using R3;

/// <summary>
/// Card(CardId)をリストとして格納するためのWrapperクラス
/// リストに要素が追加されたときなどのコールバッグが存在
/// </summary>
public class CardContainer : IList<AutoEnum.ECardID>
{


    public Observable<(int index, ECardID item)> OnCardAddedAsObservable => _onCardAddedSubject;
    public Observable<(int index, ECardID item)> OnCardRemovedAsObservable => _onCardRemovedSubject;

    List<AutoEnum.ECardID> _list = new();

    private Subject<(int index, ECardID item)> _onCardAddedSubject = new();
    private Subject<(int index, ECardID item)> _onCardRemovedSubject = new();

    public ECardID this[int index] {
        get => _list[index]; 
        set => throw new System.InvalidOperationException();
    }

    public int Count => _list.Count;

    public bool IsReadOnly => false;

    public void Add(ECardID item)
    {
        int index = GetAppropriateIndex(item);
        Insert(index, item);
        
    }

    public void Add(IEnumerable<ECardID> range)
    {
        foreach (var item in range)
        {
            Add(item);
        }
    }

    public void Clear()
    {
        ECardID[] copy = new ECardID[Count];
        CopyTo(copy, 0);
        _list.Clear();
        for (int i = 0; i < copy.Length; i++)
        {
            _onCardRemovedSubject.OnNext((i, copy[i]));
        }
    }

    public bool Contains(ECardID item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(ECardID[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ECardID> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public int IndexOf(ECardID item)
    {
        return _list.IndexOf(item);
    }

    public void Insert(int index, ECardID item)
    {
        _list.Insert(index, item);
        _onCardAddedSubject.OnNext((index, item));
    }

    public bool Remove(ECardID item)
    {
        int index = IndexOf(item);
        if(index == -1) { return false; }
        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        var item = this[index];
        _list.RemoveAt(index);
        _onCardRemovedSubject.OnNext((index, item));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// カードの適切な挿入位置を返します
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private int GetAppropriateIndex(ECardID item)
    {
        ECardID searchId = (ECardID)((int)item + 1);
        int index = IndexOf(searchId);
        if(index == -1) { return Count; }
        return index;
    }

    public (AutoEnum.ECardID, int)? GetRandom()
    {
        if (Count == 0) return null;
        int index = Random.Range(0, Count);
        return (this[index], index);
    }


    //このコンテナに存在するcardIndexのカードを他のコンテナに移動する
    public void MoveCardToAnotherContainer(int index, CardContainer anotherContainer)
    {
        var item = this[index];
        RemoveAt(index);
        anotherContainer.Add(item);
    }
}


