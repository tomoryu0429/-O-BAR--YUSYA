using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBase
{

    [SerializeField] ESlimeActions[] actions;
    private static readonly int MAXHEALTH = 20;
    private static readonly int MAXATTACK = int.MaxValue;
    private static readonly int MAXDEFECE = int.MaxValue;

    private static readonly int initialAttackValue = 5;
    private static readonly int initialDefenceValue = 2;
    
    public override int Health
    {
        get => _health.CurrentValue;
        set => _health.Value = Mathf.Clamp(value, 0, MAXHEALTH);
    }
    public override int Attack {
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public override int Defence { 
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public override Observable<int> HealthObservable => _health;
    public override Observable<int> AttackObservable => throw new System.NotImplementedException();

    public override Observable<int> DefenceObservable => throw new System.NotImplementedException();

    public override (int minHealth, int maxHealth) HealthValueRange { 
        get => (0,MAXHEALTH);
        set => throw new System.NotImplementedException();
    }
    public override (int minDefence, int MaxDefence) DefenceValueRange {
        get => (0,MAXDEFECE);
        set => throw new System.NotImplementedException();
    }
    public override (int minAttack, int maxAttack) AttackValueRange { 
        get => (0,MAXATTACK); 
        set => throw new System.NotImplementedException();
    }

    private ReactiveProperty<int> _health = new(MAXHEALTH);
    private ReactiveProperty<int> _attack = new ReactiveProperty<int>(initialAttackValue);
    private ReactiveProperty<int> _defence = new ReactiveProperty<int>(initialDefenceValue);


    private int currentActionIndex = 0;



    private enum ESlimeActions
    {
        Attack,Guard,Max
    }


    public override void PerformAttack()
    {
        ESlimeActions act = (ESlimeActions)(currentActionIndex % actions.Length);

        switch (act)
        {
            case ESlimeActions.Attack:
                _playerData.Health -= Attack;
                break;
            case ESlimeActions.Guard:
                Defence = 10;
                break;
            case ESlimeActions.Max:
                break;
        }
    }

    public override void TakeDamage(int damage)
    {
        int realDamage = damage - Defence;
        if(realDamage <= 0) { realDamage = 0; }
        

        Health -= realDamage;

        print($"{gameObject.name}‚Í{realDamage}‚ðŽó‚¯HP‚ª{Health}‚É‚È‚Á‚½");
    }
}
