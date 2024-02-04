using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("効果音")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>生成する敵のプレハブ</summary>
    [SerializeField] GameObject _enemyPrefab = default;
    [SerializeField] GameObject _enemyPrefab2 = default;
    [SerializeField] GameObject _enemyPrefab3 = default;

    /// <summary>プレハブを格納する箱/// </summary>
    public GameObject[] enemyBox = new GameObject[3];
    /// <summary>敵を生成する場所</summary>
    [SerializeField] Transform[] _spawnPoints = default;
    private float time = 0f;

    void Start()
    {
        //enemyをインスタンス化する(生成する)
        GameObject enemy = Instantiate(enemyPrefab);

    }
    // Update is called once per frame
    void Update()
    {

    }

}
