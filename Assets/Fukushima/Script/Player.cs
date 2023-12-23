using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxHP = 100;
    [SerializeField] int _maxYP = 100;
    [SerializeField] int _startHP = 100;
    [SerializeField] int _startYP = 100;
    [SerializeField] int _startdDiffence = 0;
    [SerializeField] int _hpUpDown = 0;
    [Tooltip("減らしたい場合は数値をマイナスにしてください")]
    [SerializeField] int _ypDown = 15;
    public static int _currentHP = 100;
    public static int _currentYP = 100;
    public static int _currentDif = 0; 
    public GameObject _hpTextobj;
    public GameObject _hpSystem;
    public GameObject _ypTextobj;
    public GameObject _ypSystem;
    public void Start()
    {
        _currentHP = _startHP;
        _currentYP = _startYP;
        _currentDif = _startdDiffence;
    }

    public void Update()
    {
        //"HealthText"のコンポーネントにアクセス
        //(int)はfloatを変換するため
        _hpTextobj.GetComponent<Text>().text = ((int)_currentHP).ToString();
        //HPSystemのスクリプトのHPDown()に2つの数値を送る
        _hpSystem.GetComponent<HPSystem>().HPDown(_currentHP, _maxHP);
        if (_currentHP < 0)
        {
            _currentHP = 0;
        }

        //"HealthText"のコンポーネントにアクセス
        //(int)はfloatを変換するため
        _ypTextobj.GetComponent<Text>().text = ((int)_currentYP).ToString();
        //YPSystemのスクリプトのPDown()に2つの数値を送る
        _ypSystem.GetComponent<YPSystem>().YPDown(_currentYP, _maxYP);
        if (_currentYP < 0)
        {
            _currentYP = 0;
        }
    }

    public void HPUpDown()
    {
        _currentHP += _hpUpDown;
        Debug.Log($"HP + {_hpUpDown}");
    }

    public void YPDown()
    {
        _currentYP -= _ypDown;
        Debug.Log($"YP - {_ypDown}");
    }
}
