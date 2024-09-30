using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//基本的な敵のロジックを管理するクラス
//特殊な敵はこのクラスを継承する
public  class EnemyBase : MonoBehaviour,IDamagable
{
    [SerializeField] EEnemyActions[] actions;
    [SerializeField] int _health;
    [SerializeField] int _guard;
    [SerializeField] int _attack;
    [Space(20)]
    [SerializeField,Tooltip("25%増加は1.25を指定")] float _increasePowerMultipleValue = 1.25f;
    [SerializeField, Tooltip("10増加は10を指定")] int _increaseGuardValue = 10;
    [SerializeField, Tooltip("15%の減少は15を指定")] int _decreaseYPValue = 15;


    //ステータス
    public EnemyStatus Status { get; private set; }



    private int _currentActionIndex = -1;

    protected virtual void Awake()
    {
        Status = new EnemyStatus(_health, _attack, _guard);
    }

    protected enum EEnemyActions
    {
        Attack, Guard,IncreaseAttack,Demotivate,Special
    }
    //PerformAttackの先頭で一度だけ使用
    protected EEnemyActions GetCurrentAction()
    {
        _currentActionIndex++;
        _currentActionIndex %= actions.Length;

        return actions[_currentActionIndex];
    }

    public virtual void DoAction()
    {
        var action = GetCurrentAction();

        switch (action)
        {
            case EEnemyActions.Attack:
                PerformAttack();
                break;
            case EEnemyActions.Guard:
                Status.ReinforceGuard(_increaseGuardValue);
                break;
            case EEnemyActions.IncreaseAttack:
                Status.PowerUp(_increasePowerMultipleValue);
                break;
            case EEnemyActions.Demotivate:
                PlayerData.Instance.Status.Motivation.Value -= _decreaseYPValue;
                break;
            case EEnemyActions.Special:
                break;
        }
    }

    protected virtual void PerformAttack()
    {
        PlayerData.Instance.Status.ApplyDamage(new Damage { damage = Status.Attack.Value });
        Status.PowerReset(_attack);

    }

    protected virtual void PerformSpecial()
    {
        throw new System.NotImplementedException();
    }

    public void ApplyDamage(Damage damage)
    {
        int realDamage = damage.damage - Status.Guard.Value;
        realDamage = Mathf.Max(0, realDamage);
        Status.Health.Value -= realDamage;
        Status.GuardReset(_guard);

    }
}
