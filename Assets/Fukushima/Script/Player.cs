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
    [SerializeField] int _diffence = 0;
    public static int _currentHP = 100;
    public static int _currentYP = 100;
    GameObject _hpTextobj;
    GameObject _hpSystem;
    GameObject _ypTextobj;
    GameObject _ypSystem;
    public void Start()
    {
        _currentHP = _startHP;
        _currentYP = _startYP;
        _hpTextobj = GameObject.Find("HPText");
        _hpSystem = GameObject.Find("HPSystem");
        _ypTextobj = GameObject.Find("YarukiText");
        _ypSystem = GameObject.Find("YPSystem");
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
}
