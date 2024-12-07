using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
using R3;
using Cysharp.Threading.Tasks;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyPackage _enemyPackage;

    [SerializeField] private List<Transform> _enemyRoots_1;
    [SerializeField] private List<Transform> _enemyRoots_2;
    [SerializeField] private List<Transform> _enemyRoots_3;

    public void AttackEneny(int damage)
    {
        if(_enemies[_targetIndex].Enemy.Status.Health.Value <= 0)
        {
            _targetIndex = _enemies.FindIndex(binder => binder.Enemy.Status.Health.Value > 0);
            if(_targetIndex == -1) { return; }
        }
        _enemies[_targetIndex].Enemy.ApplyDamage(new Damage { damage = damage });
    }

    private int _targetIndex = 0;
    private List<EnemyUIBinder> _enemies = new();

    public void SpawnEnemies(int enemyLevel)
    {
        EnemyPackage.PackageData data = _enemyPackage.GetCertainLevelRandomPackageData(enemyLevel);
        if(data == null) { throw new System.Exception("適合するデータが存在しません"); }
        for(int i = 0; i < data.EnemyPrefabs.Length; i++)
        {
            GameObject go = Instantiate<GameObject>(data.EnemyPrefabs[i], 
            data.EnemyPrefabs.Length switch
            {
                1 => _enemyRoots_1[i],
                2 => _enemyRoots_2[i],
                3 => _enemyRoots_3[i],
                _ => throw new System.ArgumentOutOfRangeException()
            });

            go.transform.localPosition = Vector3.zero;

            var binder = go.GetComponent<EnemyUIBinder>();
            
            binder.OnClickEvent.AsObservable().Subscribe(enemyData =>
            {
                int index = _enemies.FindIndex(binder => binder.Enemy == enemyData);
                if(_targetIndex == index) { index = 0; }
                else { _targetIndex = index; }
                print($"{enemyData.name},{_targetIndex}がターゲットされました");

            }).AddTo(this);

            _enemies.Add(binder);
        }
    }

    public bool IsAllEnemiesDie()
    {
        return System.Linq.Enumerable.All(_enemies, binder => binder.Enemy.Status.Health.Value <= 0);
    }

    public async UniTask PerformEnemiesAction()
    {
        foreach(var binder in _enemies)
        {
            if(binder.Enemy.Status.Health.Value <= 0) { continue; }
            binder.Enemy.PerformAction();
            await UniTask.Delay(1000);
        }
    }



}
