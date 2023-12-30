using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("���ʉ�")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>��������G�̃v���n�u</summary>
    [SerializeField] GameObject _enemyPrefab = default;
    /// <summary>�v���n�u���i�[���锠/// </summary>
    public GameObject[] enemyBox = new GameObject[3];
    /// <summary>�G�𐶐�����ꏊ</summary>
    [SerializeField] Transform[] _spawnPoints = default;
    private float time = 0f;
    //�G�������ԊԊu
    private float interval;

    [Header("Set X Position Min and Max")]
    //X���W�̍ŏ��l
    [Range(-10f, 0f)]
    public float xMinPosition = -10f;
    //X���W�̍ő�l
    [Range(0f, 10f)]
    public float xMaxPosition = 10f;
    [Header("Set Y Position Min and Max")]
    //Y���W�̍ŏ��l
    [Range(-10f, 0f)]
    public float yMinPosition = 0f;
    //Y���W�̍ő�l
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

        print("�G�̐��F" + enemyBox.Length);

        //���Ԍv��
        time += Time.deltaTime;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (time > interval)
        {
            //enemy���C���X�^���X������(��������)
            GameObject enemy = Instantiate(enemyBox[3]);
            //���������G�̈ʒu�������_���ɐݒ肷��
            enemy.transform.position = GetRandomPosition();
            //���������G�̍��W�����肷��(����X=0,Y=10,Z=20�̈ʒu�ɏo��)
            enemy.transform.position = new Vector3(0, 10, 20);
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0f;
        }
    }

    //�����_���Ȉʒu�𐶐�����֐�
    private Vector2 GetRandomPosition()
    {
        //���ꂼ��̍��W�������_���ɐ�������
        float x = UnityEngine.Random.Range(xMinPosition, xMaxPosition);
        float y = UnityEngine.Random.Range(yMinPosition, yMaxPosition);

        //Vector2�^��Position��Ԃ�
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
