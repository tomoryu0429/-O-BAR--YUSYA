using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class PlayerData : ICombatStatus,DamageUtility.IDamagable
{

    private PlayerData() { }

    private static PlayerData instance = null;
    public static PlayerData Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = new PlayerData();
            instance.Initialize();
            return instance;
        }
    }

    //public
    public static readonly int MAX_HP = 100;
    public static readonly int MAX_YP = 100;

    public CardManager CardManager { get; private set; }

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
    public Observable<int> MoneyObservable => money;

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
 


    private void Initialize()
    {
        CardManager = new CardManager();


        for (int i = 0; i < 8; i++)
        {
            CardManager.containers[(int)CardManager.EPileType.Draw]
                .AddCard((AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max)));

        }
    }

    public void OnTakeDamage(float damage, DamageUtility.IDamageValueBase value = null)
    {
        float realDamage = damage - Defence;
        realDamage = Mathf.Max(0, realDamage);

        Health -= (int)realDamage;
    }
}


