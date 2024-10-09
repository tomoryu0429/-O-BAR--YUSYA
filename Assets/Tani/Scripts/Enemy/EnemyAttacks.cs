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
    [Header("�_���[�W�͍U���͂��Q�Ƃ��܂�")]
    [SerializeField,ReadOnly,LabelText("���x��")] private string _actionLabel = "�U��";

    public string ActionLabel => _actionLabel;

    public void PerformAction(EnemyStatus enemyStatus)
    {
        PlayerData.Instance.Status.ApplyDamage(new Damage { damage = enemyStatus.Attack.Value });
    }
}
[System.Serializable]
public class DemotivatePlayer : IEnemyAction
{
    [Header("Player�̌���������C���w��")]
    [SerializeField] private int _decreaseValue = 10;
    [SerializeField, ReadOnly, LabelText("���x��")] private string _actionLabel = "���C����";
   

    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        PlayerData.Instance.Status.Motivation.Value -= _decreaseValue;
    }
}
[System.Serializable]
public class ReinforceGuard : IEnemyAction
{
    [Header("��������h��͂��w��")]
    [SerializeField] private int _increaseValue = 5;
    [SerializeField, ReadOnly, LabelText("���x��")] private string _actionLabel = "�h��͏㏸";
    
    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        enemyStatus.ReinforceGuard(_increaseValue);
    }
}
[System.Serializable]
public class ReinforceAttack : IEnemyAction
{
    [Header("��Z���銄�����w��")]
    [SerializeField] private float _mulValue = 1.25f;
    [SerializeField, ReadOnly, LabelText("���x��")] private string _actionLabel = "�U���͏㏸";
    
    public string ActionLabel => _actionLabel;
    public void PerformAction(EnemyStatus enemyStatus)
    {
        enemyStatus.PowerUp(_mulValue);
    }
}
