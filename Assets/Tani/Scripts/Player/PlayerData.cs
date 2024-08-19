using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class PlayerData : MonoBehaviour,ICombatStatus
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


    public Observable<int> YPObservable => yp;
    public ReadOnlyReactiveProperty<int> MoneyObservable => money;

    public int Health {
        get => hp.CurrentValue;
        set => hp.Value = Mathf.Clamp(value, 0, MAX_HP);
    }
    public int Defence { 
        get => defence.CurrentValue; 
        set => defence.Value = Mathf.Max(0,value);
    }
    public int Attack {
        get => attack.CurrentValue;
        set => attack.Value = Mathf.Max(0,value);
    }



    public Observable<int> HealthObservable => hp;
    public Observable<int> AttackObservable => attack;
    public Observable<int> DefenceObservable => defence;
    public (int minHealth, int maxHealth) HealthValueRange
    {
        get => (0,MAX_HP);
        set => throw new System.NotImplementedException();
    }
    public (int minDefence, int MaxDefence) DefenceValueRange {
        get => (0,int.MaxValue); 
        set => throw new System.NotImplementedException(); 
    }
    public (int minAttack, int maxAttack) AttackValueRange {
        get => (0, int.MaxValue); 
        set => throw new System.NotImplementedException();
    }





    //private
    ReactiveProperty<int> hp = new ReactiveProperty<int>(100);
    ReactiveProperty<int> yp = new ReactiveProperty<int>(80);
    ReactiveProperty<int> money = new ReactiveProperty<int>(0);
    ReactiveProperty<int> attack = new ReactiveProperty<int>(5);
    ReactiveProperty<int> defence = new ReactiveProperty<int>(0);
 



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


