using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("���ʉ�")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>��������G�̃v���n�u</summary>
    [SerializeField] GameObject _enemyPrefab = default;
    [SerializeField] GameObject _enemyPrefab2 = default;
    [SerializeField] GameObject _enemyPrefab3 = default;

    /// <summary>�v���n�u���i�[���锠/// </summary>
    public GameObject[] enemyBox = new GameObject[3];
    /// <summary>�G�𐶐�����ꏊ</summary>
    [SerializeField] Transform[] _spawnPoints = default;
    private float time = 0f;

    void Start()
    {
        //enemy���C���X�^���X������(��������)
        GameObject enemy = Instantiate(enemyPrefab);

    }
    // Update is called once per frame
    void Update()
    {

    }

}
