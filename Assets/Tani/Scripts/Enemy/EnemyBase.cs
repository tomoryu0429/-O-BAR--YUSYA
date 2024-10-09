using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��{�I�ȓG�̃��W�b�N���Ǘ�����N���X
//����ȓG�͂��̃N���X���p������
public  class EnemyBase : MonoBehaviour,IDamagable
{
    [SerializeField,SerializeReference] IEnemyAction[] actions;
    [SerializeField] int _health;
    [SerializeField] int _guard;
    [SerializeField] int _attack;




    //�X�e�[�^�X
    public EnemyStatus Status { get; private set; }



    private int _currentActionIndex = -1;

    protected virtual void Awake()
    {
        Status = new EnemyStatus(_health, _attack, _guard);
    }

    public void PerformAction()
    {
        _currentActionIndex++;
        _currentActionIndex %= actions.Length;

        actions[_currentActionIndex].PerformAction(Status);
    }


   
 
    public void ApplyDamage(Damage damage)
    {
        int realDamage = damage.damage - Status.Guard.Value;
        realDamage = Mathf.Max(0, realDamage);
        Status.Health.Value -= realDamage;
        Status.GuardReset();

    }
}
