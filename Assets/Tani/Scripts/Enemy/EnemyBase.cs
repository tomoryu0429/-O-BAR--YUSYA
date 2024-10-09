using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//基本的な敵のロジックを管理するクラス
//特殊な敵はこのクラスを継承する
public  class EnemyBase : MonoBehaviour,IDamagable
{
    [SerializeField,SerializeReference] IEnemyAction[] actions;
    [SerializeField] int _health;
    [SerializeField] int _guard;
    [SerializeField] int _attack;




    //ステータス
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
