using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーのステータスを管理するクラスです
public class PlayerStatus : IDamagable
{
    public PlayerStatus()
    {
        Health = new ReactiveStatus(100, 100);
        Motivation = new ReactiveStatus(80, 100);
        Attack = new ReactiveStatus(10, int.MaxValue);
        Guard = new ReactiveStatus(0, int.MaxValue);
        Money = new ReactiveStatus(0, int.MaxValue);
        RemainingUseCount = new ReactiveStatus(0, int.MaxValue);
        PlayerDieAsObservable = 
            Health.Observable.Where(health => health.Value == 0)
            .AsUnitObservable().Publish();
    }

    public Observable<Unit> PlayerDieAsObservable { get; }

    public void ApplyDamage(Damage damage)
    {
        int realDamage = damage.damage - Guard.Value;
        realDamage = Mathf.Max(0, realDamage);
        Health.Value -= realDamage;
    }

    public void ResetTempStatus()
    {
        RemainingUseCount.Value = 1;
        Guard.Value = 0;
    }

    public ReactiveStatus Health { get; private set; } = null;
    public ReactiveStatus Attack { get; private set; } = null;
    public ReactiveStatus Guard { get; private set; } = null;
    public ReactiveStatus Motivation { get; private set; } = null;

    public ReactiveStatus Money { get; private set; } = null;
    public ReactiveStatus RemainingUseCount { get; private set; } = null;

}

