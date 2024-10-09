using Alchemy.Inspector;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPackage", menuName = "ScriptableObjects/EnemyPackage")]
public class EnemyPackage : ScriptableObject
{
    [System.Serializable]
    public class PackageData
    {
        [field: SerializeField] public GameObject[] EnemyPrefabs { get; private set; }
        [field: SerializeField] public int Level = 0;

    }

    [SerializeField]
    private List<PackageData> _enemyDatas;

    public PackageData GetCertainLevelRandomPackageData(int level)
    {
        var correctDatas = _enemyDatas.FindAll(x => x.Level == level);
        if(correctDatas.Count == 0) { throw new System.NullReferenceException(); }
        return correctDatas[(int)(Random.value * correctDatas.Count)];
    }
    
}
