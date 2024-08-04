using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBase
{

    [SerializeField] ESlimeActions[] actions;

    public override int Health
    {
        get => health.CurrentValue;
        set => health.Value = Mathf.Clamp(value, 0, 10);
    }

    public override ReadOnlyReactiveProperty<int> HealthProperty => health.ToReadOnlyReactiveProperty();


    private int currentActionIndex = 0;
    const int MaxHealth = 10;



    private ReactiveProperty<int> health = new(MaxHealth);

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

    public override void GetDamage(int damage)
    {
        int realDamage = damage - Defence;
        if(realDamage <= 0) { realDamage = 0; }
        Defence = 0;

        Health -= realDamage;
    }
}
