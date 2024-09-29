using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーのステータスを管理するクラスです
public class PlayerStatus 
{
    public PlayerStatus()
    {
        HealthObservable = new ReactiveProperty<Health_Status>(new Health_Status(100, 100));
        YarukiObservable = new ReactiveProperty<Yaruki_Status>(new Yaruki_Status(100, 100));
        AttackObservable = new ReactiveProperty<Attack_Status>(new Attack_Status(10, int.MaxValue));
        GuardObservable  = new ReactiveProperty<Guard_Status>(new Guard_Status(5, int.MaxValue));
        MoneyObservable = new ReactiveProperty<Money_Status>(new Money_Status(100, int.MaxValue));
    }

    public void ApplyDamage(int damage)
    {
        var realDamage = damage - GuardObservable.Value.Value;
        realDamage = Mathf.Max(0, realDamage);
        HealthObservable.Value = HealthObservable.Value.ChangeValue(-realDamage,HealthObservable.Value.Max);
    }

    public void RecoveryHealth(int recoveryHealth)
    {
        recoveryHealth = Mathf.Max(0, recoveryHealth);
        HealthObservable.Value = HealthObservable.Value.ChangeValue(recoveryHealth, HealthObservable.Value.Max);
    }

    public void IncreaseYaruki(int value)
    {
        value = Mathf.Max(0, value);
        YarukiObservable.Value = YarukiObservable.Value.ChangeValue(value, YarukiObservable.Value.Max);
    }
    public void DecreaseYaruki(int value)
    {
        value = Mathf.Max(0, value);
        YarukiObservable.Value = YarukiObservable.Value.ChangeValue(-value, YarukiObservable.Value.Max);
    }

    public void IncreaseAttack(int value)
    {
        value = Mathf.Max(0, value);
        AttackObservable.Value = AttackObservable.Value.ChangeValue(value, AttackObservable.Value.Max);
    }
    public void DecreaseAttack(int value)
    {
        value = Mathf.Max(0, value);
        AttackObservable.Value = AttackObservable.Value.ChangeValue(-value, AttackObservable.Value.Max);
    }
    public void IncreaseGuard(int value)
    {
        value = Mathf.Max(0, value);
        GuardObservable.Value = GuardObservable.Value.ChangeValue(value, GuardObservable.Value.Max);
    }
    public void DecreaseGuard(int value)
    {
        value = Mathf.Max(0, value);
        GuardObservable.Value = GuardObservable.Value.ChangeValue(-value, GuardObservable.Value.Max);
    }

    public void GainMoney(int value)
    {
        value = Mathf.Max(0, value);
        MoneyObservable.Value = MoneyObservable.Value.ChangeValue(value, MoneyObservable.Value.Max);
    }
    public void SpendMoney(int value)
    {
        if(!MoneyObservable.Value.IsEnough(value))
        {
            throw new System.Exception($"money is not decent ,Current :{MoneyObservable.Value.Value},Require : {value}");
        }
        MoneyObservable.Value = MoneyObservable.Value.ChangeValue(-value, MoneyObservable.Value.Max);
    }

    public ReactiveProperty<Health_Status> HealthObservable { get; }
    public ReactiveProperty<Yaruki_Status> YarukiObservable{ get; }
    public ReactiveProperty<Attack_Status> AttackObservable { get; }
    public ReactiveProperty<Guard_Status> GuardObservable { get; }
    public ReactiveProperty<Money_Status> MoneyObservable { get; }

    



}

//new()制約の実行速度を回避しつつabstractClass化したStatus
public abstract class Status<T> 
{
    public Status(int value, int max)
    {
        if (value < 0 || max < 0)
        {
            throw new System.Exception($"値が0以下です value : {value},max : {max}");
        }
        if (max < value)
        {
            throw new System.Exception($"Maxがvalueよりも小さいです Value : {value}, Max : {max}");
        }
        _value = value;
        _max = max;
    }
    protected abstract T CreateInstance(int value,int max);

    public int Value { get => _value; }
    public int Max { get => _max; }


    public T SetValue(int value, int max)
    {
        if (value <= 0) { value = 0; }
        if (max <= 0) { max = 0; }
        if (value > max) { value = max; }
        return CreateInstance(value, max);
    }


    public T ChangeValue(int value_diff, int max_diff)
    {
        return SetValue(_value + value_diff, _max + max_diff);
    }

    //private
    private readonly int _value;
    private readonly int _max;



}

public class Health_Status : Status<Health_Status>
{
    public Health_Status(int value, int max) : base(value, max)
    {
    }

    protected override Health_Status CreateInstance(int value, int max)
    {
        return new Health_Status(value, max);
    }
}

public class Yaruki_Status : Status<Yaruki_Status>
{
    public Yaruki_Status(int value, int max) : base(value, max)
    {
    }

    protected override Yaruki_Status CreateInstance(int value, int max)
    {
        return new Yaruki_Status(value, max);
    }
}

public class Attack_Status : Status<Attack_Status>
{
    public Attack_Status(int value, int max) : base(value, max)
    {
    }

    protected override Attack_Status CreateInstance(int value, int max)
    {
        return new Attack_Status(value, max);
    }
}

public class Guard_Status : Status<Guard_Status>
{
    public Guard_Status(int value, int max) : base(value, max)
    {
    }

    protected override Guard_Status CreateInstance(int value, int max)
    {
        return new Guard_Status(value, max);
    }
}

public class Money_Status : Status<Money_Status>
{
    public Money_Status(int value, int max) : base(value, max)
    {
    }

    protected override Money_Status CreateInstance(int value, int max)
    {
        return new Money_Status(value, max);
    }

    public bool IsEnough(int money)
    {
        return Value >= money;
    }
}