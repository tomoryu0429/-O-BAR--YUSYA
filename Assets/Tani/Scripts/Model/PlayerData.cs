using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class PlayerData : MonoBehaviour
{
    //public
    public static readonly int MAX_HP = 100;
    public static readonly int MAX_YP = 100;
    public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();
    

    /// <summary>
    /// 勇者のHPの取得と設定、値は 0 - MAX_HPにクランプされる
    /// </summary>
    public int HP
    {
        get => hp.Value;
        set => hp.Value = Mathf.Clamp(value, 0, MAX_HP);
    }
    /// <summary>
    /// 勇者のやる気ポイントの取得と設定、値は0 - MAX_YPにクランプされる
    /// </summary>
    public int YP
    {
        get => yp.Value;
        set => yp.Value = Mathf.Clamp(value, 0, MAX_YP);
    }
    /// <summary>
    ///勇者の所持金
    /// </summary>
    public int Money
    {
        get => money.Value;
        set => money.Value = value;
    }
    public CardManager CardManager => cardManager ?? GetComponent<CardManager>();


    public ReadOnlyReactiveProperty<int> ReactiveProperty_HP => hp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_YP => yp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Money => money.ToReadOnlyReactiveProperty();


    //private
    ReactiveProperty<int> hp = new ReactiveProperty<int>(MAX_HP);
    ReactiveProperty<int> yp = new ReactiveProperty<int>(MAX_YP);
    ReactiveProperty<int> money = new ReactiveProperty<int>(0);
    CardManager cardManager = null;

    //protected override void Awake()
    //{
    //    base.Awake();
    //    if(!gameObject.TryGetComponent<CardManager>(out cardManager))
    //    {
    //        cardManager = gameObject.AddComponent<CardManager>();
    //    }



    //}

    private  void Awake()
    {
        if (!gameObject.TryGetComponent<CardManager>(out cardManager))
        {
            cardManager = gameObject.AddComponent<CardManager>();
        }
        

        CS_Init.TrySetResult();
    }
    private async void Start()
    {
        CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(CardData.ECardID.Meet);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Meet);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Meet);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Meet);

        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Fish);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Fish);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Onion);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Rice);
        CardManager.containers[(int)CardManager.EPileType.Draw].AddCard(CardData.ECardID.Rice);




    }

}


