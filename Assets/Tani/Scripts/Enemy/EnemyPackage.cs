using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPackage", menuName = "ScriptableObjects/EnemyPackage")]
public class EnemyPackage : ScriptableObject
{
    [System.Serializable]
    public class PackageData
    {
        [field: SerializeField] public GameObject enemyPrefab { get; private set; }
        [field: SerializeField] public Vector3 spawnPosition { get; private set; }

    }

    [SerializeField]
    private List<PackageData> _enemyDatas;

    public IReadOnlyList<PackageData> EnemyDatas
    {
        get => _enemyDatas;
    }
    
    
 
    public static IEnumerable<EnemyBase> InstEnemies(IEnumerable<PackageData> packDatas,Transform parent)
    {
        foreach(PackageData data in packDatas)
        {
            var e = Instantiate(data.enemyPrefab,parent).GetComponent<EnemyBase>();
            e.gameObject.transform.localPosition = data.spawnPosition;
            yield return e;
        }
    }
}
