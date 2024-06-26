using System.Collections.Generic;
using Yusya.Enum;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{
    HPBar HPBar;

    // 敵の出現ポイント.
    [SerializeField] List<Transform> enemySpawnPoints = new List<Transform>();
    [SerializeField] GameObject[] _enemyPrefabs;
    [SerializeField] int _enemyAttack = 0;
    [SerializeField] HPStatus _hpStatus = 0;

    void Start()
    {
        foreach(var point  in enemySpawnPoints)
        {
            int number = Random.Range(0, _enemyPrefabs.Length);
            //enemyをインスタンス化する(ランダム生成する)
            Instantiate(_enemyPrefabs[number],point.position,Quaternion.identity);
        }
    }
    //敵の攻撃処理

    public void Update()
    {
         if (_hpStatus < 0)
        {
            Debug.Log("敵死亡");
            this.gameObject.SetActive(false);
        }//敵の死亡処理
    }
    public void eTurn()
    {

    }
}
