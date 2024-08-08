using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,IHealth
{
    public abstract int Health { get; set; }
    public abstract int MaxHealth { get; set; }

    public abstract ReadOnlyReactiveProperty<int> HealthProperty { get; }


    [field: SerializeField] protected int Attack { get; set; } = 10;
    [field: SerializeField] protected int Defence { get; set; } = 10;

    protected PlayerData _playerData;
    public void Init(PlayerData playerData) { _playerData = playerData; }
    public abstract void PerformAttack();
    public abstract void GetDamage(int damage);

}
