using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] int _maxHP = 100;
    [SerializeField] float _currentHP;
    GameObject _textobj;
    Text _text;
    GameObject _hpSystem;

    private void Start()
    {
        _textobj = GameObject.Find("HealthText");
        _hpSystem = GameObject.Find("HPSystem");
    }

    private void Update()
    {
        //"HealthText"�̃R���|�[�l���g�ɃA�N�Z�X
        //(int)��float��ϊ����邽��
        _textobj.GetComponent<Text>().text = ((int)_currentHP).ToString();
        //HPSystem�̃X�N���v�g��HPDown()��2�̐��l�𑗂�
        _hpSystem.GetComponent<HPSystem>().HPDown(_currentHP, _maxHP);
    }

    private void FixedUpdate()
    {
        if (0 <= _currentHP)
        {
            _currentHP = _maxHP - Time.time * 10;
        }
    }
}
