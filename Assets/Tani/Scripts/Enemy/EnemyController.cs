using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
using R3;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<EnemyPackage> _enemyPacks;
    [SerializeField] bool UseFixedIndex = false;
    [SerializeField, ShowIf(nameof(UseFixedIndex))] int _index = 0;
    [SerializeField, AssetsOnly] GameObject selectArrowImageObject; 

    EnemyBase _currentPlayerTarget = null;
    EnemyPackage _selectedPack;
    List<EnemyBase> _enemies = new();


    public void SpawnEnemies()
    {

        if (!UseFixedIndex)
        {
            int _index = Mathf.FloorToInt(Random.Range(0, _enemyPacks.Count));

        }
        _selectedPack = _enemyPacks[_index];

        _enemies = EnemyPackage.InstEnemies(_selectedPack.EnemyDatas, transform).ToList();

        foreach(var e in _enemies)
        {
            e.gameObject.GetComponent<EnemyUIBinder>()
                .OnClickEvent
                .AsObservable()
                .Subscribe(SetTargetEnemy)
                .AddTo(this);

        }
    }



    public void SetTargetEnemy(EnemyBase enemy)
    {
        print($"{enemy.transform.position}");
        _currentPlayerTarget = enemy;

    }

}
