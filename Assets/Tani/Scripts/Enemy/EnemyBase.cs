using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyBase : MonoBehaviour,ICombatStatus,DamageUtility.IDamagable
{
    [SerializeField] EEnemyActions[] actions;
    [SerializeField] SerializableReactiveProperty<int> _health;
    [SerializeField] SerializableReactiveProperty<int> _defence;
    [SerializeField] SerializableReactiveProperty<int> _attack;
    [SerializeField,Tooltip("25%増加は1.25を指定")] float _increasePowerMultipleValue = 1.25f;
    [SerializeField, Tooltip("10増加は10を指定")] int _increaseDefenceValue = 10;
    [SerializeField, Tooltip("15%の減少は15を指定")] int _decreaseYPValue = 15;


    private int MAXHEALTH;
    private bool isIncreasedPower = false;
    private int _currentActionIndex = -1;

    protected virtual void Awake()
    {
        MAXHEALTH = _health.CurrentValue;
    }

    protected enum EEnemyActions
    {
        Attack, Guard,IncreaseAttack,Demotivate, Max
    }
    public  int Health
    {
        get => _health.CurrentValue;
        set => _health.Value = Mathf.Clamp(value, 0, MAXHEALTH);
    }
    public  int Attack
    {
        get => (int)(isIncreasedPower ? _attack.Value * _increasePowerMultipleValue : _attack.Value);
        set => _attack.Value = Mathf.Max(0, value);
    }

    public  int Defence
    {
        get => _defence.CurrentValue;
        set => _defence.Value = Mathf.Max(0, value);
    }


    public  Observable<int> HealthObservable { get => _health; }
    public  Observable<int> DefenceObservable { get => _defence; }
    public  Observable<int> AttackObservable { get => _attack; }
    
    public  (int minHealth, int maxHealth) HealthValueRange { 
        get => (0,MAXHEALTH);
        set => throw new System.NotImplementedException(); 
    }

    public virtual (int minDefence, int MaxDefence) DefenceValueRange { 
        get => throw new System.NotImplementedException(); 
        set => throw new System.NotImplementedException(); 
    }
    public virtual (int minAttack, int maxAttack) AttackValueRange { 
        get => throw new System.NotImplementedException();
        set => throw new System.NotImplementedException();
    }

    public  void OnTakeDamage(float damage, DamageUtility.IDamageValueBase value = null)
    {
        int readDamage = (int)Mathf.Max(0,damage - Defence);
        Defence = 0;

        Health -= readDamage;
    }


    public virtual void PerformAttack()
    {
        var action = GetCurrentAction();

        switch (action)
        {
            case EEnemyActions.Attack:
                DamageUtility.ApplyDamage(PlayerData.Instance, Attack);
                isIncreasedPower = false;
                break;
            case EEnemyActions.Guard:
                Defence += _increaseDefenceValue;
                break;
            case EEnemyActions.IncreaseAttack:
                isIncreasedPower = true;
                break;
            case EEnemyActions.Demotivate:
                PlayerData.Instance.YP -= _decreaseYPValue;
                break;
            case EEnemyActions.Max:
                break;
        }
    }

    //PerformAttackの先頭で一度だけ使用
    protected EEnemyActions GetCurrentAction()
    {
        _currentActionIndex++;
        _currentActionIndex %= actions.Length;

        return actions[_currentActionIndex];
    }

}
