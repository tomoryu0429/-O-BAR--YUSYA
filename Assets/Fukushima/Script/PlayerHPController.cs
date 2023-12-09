using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPController : MonoBehaviour
{
/*    [SerializeField] int _maxHP = 100;
    [SerializeField] int _startHP = 100;
    public static float _currentHP;
    GameObject _textobj;
    GameObject _hpSystem;*/

/*    private void Start()
    {
        _currentHP = _startHP;
        _textobj = GameObject.Find("HPText");
        _hpSystem = GameObject.Find("HPSystem");
    }

    private void Update()
    {
        //"HealthText"のコンポーネントにアクセス
        //(int)はfloatを変換するため
        _textobj.GetComponent<Text>().text = ((int)_currentHP).ToString();
        //HPSystemのスクリプトのHPDown()に2つの数値を送る
        _hpSystem.GetComponent<HPSystem>().HPDown(_currentHP, _maxHP);
        if (_currentHP < 0)
        {
            _currentHP = 0;
        }
    }*/
}
