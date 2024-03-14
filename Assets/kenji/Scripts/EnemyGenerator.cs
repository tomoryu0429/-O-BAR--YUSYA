using System.Collections.Generic;
using UnityEngine;
//https://note.com/midorigamegame/n/nf6f8ef51cdf7
public class EnemyGenerator : MonoBehaviour
{

    // 敵の出現ポイント.
    [SerializeField] List<Transform> enemySpawnPoints = new List<Transform>();
    private float time = 0f;
    [SerializeField] GameObject[] _enemyPrefabs;

    void Start()
    {
        foreach(var point  in enemySpawnPoints)
        {
            int number = Random.Range(0, _enemyPrefabs.Length);
            //enemyをインスタンス化する(ランダム生成する)
            Instantiate(_enemyPrefabs[number],point.position,Quaternion.identity);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

}
