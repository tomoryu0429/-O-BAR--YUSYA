using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_Player : MonoBehaviour
{
    [SerializeField] public static int _maxHP = 100;
    [SerializeField] public static int  _maxYP = 100;
    [SerializeField] int _hpUpDown = 0;
    [Tooltip("減らしたい場合は数値をマイナスにしてください")]
    [SerializeField] int _ypDown = 15;
    public static int _currentHP = 100;
    public static int _currentYP = 100;
    public static int _currentDif = 0;
   // public GameObject _hpTextobj;
   // public GameObject _ypTextobj;
    public void Start()
    {
        _currentHP = _maxHP;
        _currentYP = _maxYP;
        _currentDif = 0;
    }

    public void Update()
    {
        //"HealthText"のコンポーネントにアクセス
        //(int)はfloatを変換するため
        //  _hpTextobj.GetComponent<Text>().text = ((int)_currentHP).ToString();


        //"HealthText"のコンポーネントにアクセス
        //(int)はfloatを変換するため
        // _ypTextobj.GetComponent<Text>().text = ((int)_currentYP).ToString();
        //値が突き抜けないように
        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
        if (_currentYP > _maxYP)
        {
            _currentYP = _maxYP;
        }
        if (_currentYP <= 0)
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

    public void DefReset()
    {
        _currentDif = 0;
        Debug.Log("防御力がリセットされた");
    }

    public void pAttack()
    {
        YPDown();
        TurnManager.turnState = TurnState.EnemyAttack;
    }
}
