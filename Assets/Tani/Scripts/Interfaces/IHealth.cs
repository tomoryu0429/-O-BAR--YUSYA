using R3;
using UnityEngine.Events;

public interface IHealth
{
    int Health { get; set; }
    int MaxHealth { get; set; }

    ReadOnlyReactiveProperty<int> HealthProperty { get; }
}
