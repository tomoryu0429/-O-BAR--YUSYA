using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    public EnemyBase CurrentTarget { get; set; }

    public void AttackEnemy()
    {
        print($"{CurrentTarget.gameObject.name}‚ÉUŒ‚");
        CurrentTarget.GetDamage(_playerData.Attack);
    }
}
