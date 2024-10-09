using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
using R3;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyPackage _enemyPackage;

    [SerializeField] private List<Transform> _enemyRoots_1;
    [SerializeField] private List<Transform> _enemyRoots_2;
    [SerializeField] private List<Transform> _enemyRoots_3;
    
    public EnemyBase TargetEnemy => _enemies.Find(data => data.Status.Health.Value != 0);

    private List<EnemyBase> _enemies = new();

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
            _enemies.Add(go.GetComponent<EnemyBase>());
        }
    }





}
