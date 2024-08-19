using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour,ICombatStatus
{
    public abstract int Health { get; set; }
    public abstract Observable<int> HealthObservable { get; }
    public abstract (int minHealth, int maxHealth) HealthValueRange { get; set; }

    public abstract int Defence { get; set; }
    public abstract Observable<int> DefenceObservable { get; }
    public abstract (int minDefence, int MaxDefence) DefenceValueRange { get; set; }
    public abstract int Attack { get; set; }
    public abstract Observable<int> AttackObservable { get; }
    public abstract (int minAttack, int maxAttack) AttackValueRange { get; set; }


    protected PlayerData _playerData;

    public void Init(PlayerData playerData) { _playerData = playerData; }
    public abstract void PerformAttack();
    public abstract void TakeDamage(int damage);

}
