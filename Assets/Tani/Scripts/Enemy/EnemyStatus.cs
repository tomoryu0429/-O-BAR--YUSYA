using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;

public class EnemyStatus 
{
    public EnemyStatus(int health,int attack,int guard)
    {
        _initialAttack = attack;
        _initialGuard = guard;

        Health = new ReactiveStatus(health, health);
        Attack = new ReactiveStatus(attack, int.MaxValue);
        Guard = new ReactiveStatus(guard, int.MaxValue);

        DieAsObservable = Health.Observable.Where(health => health.Value == 0).AsUnitObservable().Publish();
    }

    public void PowerUp(float mul)
    {
        Attack.Value = (int)(Attack.Value * mul);
        _isPowerUpSubject.OnNext(true);
    }
    public void PowerReset()
    {
        Attack.Value = _initialAttack;
    }

    public void ReinforceGuard(int increase)
    {
        Guard.Value += increase;
        _isReinforcedGuardSubject.OnNext(true);
    }
    public void GuardReset()
    {
        Guard.Value = _initialGuard;
    }

    public ReactiveStatus Health { get; private set; } = null;
    public ReactiveStatus Attack { get; private set; } = null;
    public ReactiveStatus Guard { get; private set; } = null;
    public Observable<bool> IsPowerUpAsObservable  => _isPowerUpSubject;
    public Observable<bool> IsReinforcedGuardSubject => _isReinforcedGuardSubject;
    public Observable<Unit> DieAsObservable { get; }

    private Subject<bool> _isPowerUpSubject = new Subject<bool>();
    private Subject<bool> _isReinforcedGuardSubject = new Subject<bool>();
    private int _initialAttack;
    private int _initialGuard;
}
