using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class PlayerData : MonoBehaviour,IHealth
{
    //public
    public static readonly int MAX_HP = 100;
    public static readonly int MAX_YP = 100;
    public UniTaskCompletionSource CS_Init { get; private set; } = new UniTaskCompletionSource();

    [field: SerializeField]public CardManager CardManager { get; private set; }

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

    public int Attack
    {
        get => attack.Value;
        set => attack.Value = value;
    }
    public int Diffense
    {
        get => diffese.Value;
        set => diffese.Value = value;
    }

    public ReadOnlyReactiveProperty<int> ReactiveProperty_YP => yp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Money => money.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Attack => attack.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReactiveProperty_Diffense => diffese.ToReadOnlyReactiveProperty();

    public ReadOnlyReactiveProperty<int> HealthProperty { 
        get => hp.ToReadOnlyReactiveProperty();
    }
    public int Health {
        get => hp.CurrentValue;
        set => hp.Value = Mathf.Clamp(value, 0, MAX_HP);
    }



    //private
    ReactiveProperty<int> hp = new ReactiveProperty<int>(MAX_HP);
    ReactiveProperty<int> yp = new ReactiveProperty<int>(MAX_YP);
    ReactiveProperty<int> money = new ReactiveProperty<int>(0);
    ReactiveProperty<int> attack = new ReactiveProperty<int>(0);
    ReactiveProperty<int> diffese = new ReactiveProperty<int>(0);
 



    private void Start()
    {
        CardManager = GetComponent<CardManager>();

        CS_Init.TrySetResult();

        for(int i = 0; i < 8 ; i++)
        {
            CardManager.containers[(int)CardManager.EPileType.Draw]
                .AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));

        }



    }

}


