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
        //"HealthText"のコンポーネントにアクセス
        //(int)はfloatを変換するため
        _textobj.GetComponent<Text>().text = ((int)_currentHP).ToString();
        //HPSystemのスクリプトのHPDown()に2つの数値を送る
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
