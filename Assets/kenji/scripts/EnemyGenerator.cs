using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("効果音")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>生成する敵のプレハブ</summary>
    [SerializeField] GameObject _enemyPrefab = default;
    /// <summary>プレハブを格納する箱/// </summary>
    public GameObject[] enemyBox = new GameObject[3];
    /// <summary>敵を生成する場所</summary>
    [SerializeField] Transform[] _spawnPoints = default;
    private float time = 0f;
    //敵生成時間間隔
    private float interval;

    [Header("Set X Position Min and Max")]
    //X座標の最小値
    [Range(-10f, 0f)]
    public float xMinPosition = -10f;
    //X座標の最大値
    [Range(0f, 10f)]
    public float xMaxPosition = 10f;
    [Header("Set Y Position Min and Max")]
    //Y座標の最小値
    [Range(-10f, 0f)]
    public float yMinPosition = 0f;
    //Y座標の最大値
    [Range(0f, 20f)]
    public float yMaxPosition = 10f;

    //private void nMouseEnter()
    //{
    //    _life = 0;
    //}
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        enemyBox = GameObject.FindGameObjectsWithTag("Enemy");

        print("敵の数：" + enemyBox.Length);

        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(enemyBox[3]);
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
            //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
            enemy.transform.position = new Vector3(0, 10, 20);
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
        }
    }

    //ランダムな位置を生成する関数
    private Vector2 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = UnityEngine.Random.Range(xMinPosition, xMaxPosition);
        float y = UnityEngine.Random.Range(yMinPosition, yMaxPosition);

        //Vector2型のPositionを返す
        return new Vector2(x, y);
    }
    private void Randomprint()
    {
        if (enemyBox == null)
        {
            Instantiate(_enemyPrefab);
        }
    }

    IEnumerator GenerateRoutine()
    {
        while (true)
        {
            System.Array.ForEach(_spawnPoints, t => Instantiate(_enemyPrefab, t.position, Quaternion.identity));
        }
    }
}
