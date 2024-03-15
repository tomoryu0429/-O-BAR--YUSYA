using System.Collections.Generic;
using Yusya.Enum;
using UnityEngine;
public class EnemyGenerator : MonoBehaviour
{

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
    public void eAttack()
    {
        T_Player._currentHP -= _enemyAttack - T_Player._currentDif;
        TurnManager.turnState = TurnState.End;
    }
    public void Update()
    {
         if (_hpStatus < 0)
        {
            Debug.Log("敵死亡");
            this.gameObject.SetActive(false);
        }
    }
}
