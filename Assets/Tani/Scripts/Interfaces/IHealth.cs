using R3;
using UnityEngine.Events;

public interface IHealth
{
    int Health { get; set; }    
    (int minHealth,int maxHealth) HealthValueRange { get; set; }

    Observable<int> HealthObservable { get; }
}

public interface ICombatStatus : IHealth
{
    int Defence { get; set; }
    Observable<int> DefenceObservable { get; }
    (int minDefence,int MaxDefence) DefenceValueRange { get; set; }

    int Attack { get; set; }
    Observable<int> AttackObservable { get; }

    (int minAttack,int maxAttack) AttackValueRange { get; set; }
}