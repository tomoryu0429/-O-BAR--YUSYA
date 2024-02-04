using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _player = default;
    [Tooltip("���ʉ�")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>��������G�̃v���n�u</summary>
    [SerializeField] GameObject[] _enemyPrefabs = default;
    // �G�̏o���|�C���g.
    [SerializeField] List<Transform> enemySpawnPoints = new List<Transform>();
    //��������G�̃v���n�u�����X�g�ɓ����
    List<int> enemyList = new List<int>();
    //List<string> enemyNames = new List<string>();
    private float time = 0f;

    void Start()
    {
        _enemyPrefabs = GameObject.FindGameObjectsWithTag("Enemy");
        _player = GameObject.FindGameObjectWithTag("Player");
        //enemy���C���X�^���X������(��������)
        //GameObject enemy = Instantiate(_enemyPrefabs);

    }
    // Update is called once per frame
    void Update()
    {

    }

}
