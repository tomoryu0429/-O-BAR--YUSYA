using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _player = default;
    [Tooltip("効果音")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>生成する敵のプレハブ</summary>
    [SerializeField] GameObject[] _enemyPrefabs = default;
    // 敵の出現ポイント.
    [SerializeField] List<Transform> enemySpawnPoints = new List<Transform>();
    //生成する敵のプレハブをリストに入れる
    List<int> enemyList = new List<int>();
    //List<string> enemyNames = new List<string>();
    private float time = 0f;

    void Start()
    {
        _enemyPrefabs = GameObject.FindGameObjectsWithTag("Enemy");
        _player = GameObject.FindGameObjectWithTag("Player");
        //enemyをインスタンス化する(生成する)
        //GameObject enemy = Instantiate(_enemyPrefabs);

    }
    // Update is called once per frame
    void Update()
    {

    }

}
