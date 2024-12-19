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
    [Header("ƒ_ƒ[ƒW‚ÍUŒ‚—Í‚ðŽQÆ‚µ‚Ü‚·")]
    [SerializeField,ReadOnly,LabelText("ƒ‰ƒxƒ‹")] private string _actionLabel = "UŒ‚";

    public string ActionLabel => _actionLabel;

    public void PerformAction(EnemyStatus enemyStatus)
    {
        PlayerData.Instance.Status.ApplyDamage(new Damage { damage = enemyStatus.Attack.Value });
    }
}
[System.Serializable]
public class DemotivatePlayer : IEnemyAction
{
    [Header("Player‚ÌŒ¸­‚·‚é‚â‚é‹C‚ðŽw’è")]
    [SerializeField] private int _decreaseValue = 10;
    [SerializeField, ReadOnly, LabelText("ƒ‰ƒxƒ‹")] private string _actionLabel = "‚â‚é‹CŒ¸­";
   

    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        PlayerData.Instance.Status.Motivation.Value -= _decreaseValue;
    }
}
[System.Serializable]
public class ReinforceGuard : IEnemyAction
{
    [Header("‘‰Á‚·‚é–hŒä—Í‚ðŽw’è")]
    [SerializeField] private int _increaseValue = 5;
    [SerializeField, ReadOnly, LabelText("ƒ‰ƒxƒ‹")] private string _actionLabel = "–hŒä—Íã¸";
    
    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        enemyStatus.ReinforceGuard(_increaseValue);
    }
}
[System.Serializable]
public class ReinforceAttack : IEnemyAction
{
    [Header("æŽZ‚·‚éŠ„‡‚ðŽw’è")]
    [SerializeField] private float _mulValue = 1.25f;
    [SerializeField, ReadOnly, LabelText("ƒ‰ƒxƒ‹")] private string _actionLabel = "UŒ‚—Íã¸";
    
    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        enemyStatus.PowerUp(_mulValue);
    }
}
