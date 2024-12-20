using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAction
{
    string ActionLabel { get; }
    void PerformAction(EnemyStatus enemyStatus);
}

[System.Serializable]
public class AttackPlayer : IEnemyAction
{
    [Header("ダメージは攻撃力を参照します")]
    [SerializeField,ReadOnly,LabelText("ラベル")] private string _actionLabel = "攻撃";

    public string ActionLabel => _actionLabel;

    public void PerformAction(EnemyStatus enemyStatus)
    {
        PlayerData.Instance.Status.ApplyDamage(new Damage { damage = enemyStatus.Attack.Value });
    }
}
[System.Serializable]
public class DemotivatePlayer : IEnemyAction
{
    [Header("Playerの減少するやる気を指定")]
    [SerializeField] private int _decreaseValue = 10;
    [SerializeField, ReadOnly, LabelText("ラベル")] private string _actionLabel = "やる気減少";
   

    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        PlayerData.Instance.Status.Motivation.Value -= _decreaseValue;
    }
}
[System.Serializable]
public class ReinforceGuard : IEnemyAction
{
    [Header("増加する防御力を指定")]
    [SerializeField] private int _increaseValue = 5;
    [SerializeField, ReadOnly, LabelText("ラベル")] private string _actionLabel = "防御力上昇";
    
    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        enemyStatus.ReinforceGuard(_increaseValue);
    }
}
[System.Serializable]
public class ReinforceAttack : IEnemyAction
{
    [Header("乗算する割合を指定")]
    [SerializeField] private float _mulValue = 1.25f;
    [SerializeField, ReadOnly, LabelText("ラベル")] private string _actionLabel = "攻撃力上昇";
    
    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        enemyStatus.PowerUp(_mulValue);
    }
}
