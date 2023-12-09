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
        //"HealthText"�̃R���|�[�l���g�ɃA�N�Z�X
        //(int)��float��ϊ����邽��
        _hpTextobj.GetComponent<Text>().text = ((int)_currentHP).ToString();
        //HPSystem�̃X�N���v�g��HPDown()��2�̐��l�𑗂�
        _hpSystem.GetComponent<HPSystem>().HPDown(_currentHP, _maxHP);
        if (_currentHP < 0)
        {
            _currentHP = 0;
        }

        //"HealthText"�̃R���|�[�l���g�ɃA�N�Z�X
        //(int)��float��ϊ����邽��
        _ypTextobj.GetComponent<Text>().text = ((int)_currentYP).ToString();
        //YPSystem�̃X�N���v�g��PDown()��2�̐��l�𑗂�
        _ypSystem.GetComponent<YPSystem>().YPDown(_currentYP, _maxYP);
        if (_currentYP < 0)
        {
            _currentYP = 0;
        }
    }
}
