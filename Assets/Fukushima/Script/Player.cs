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
    [Tooltip("���炵�����ꍇ�͐��l���}�C�i�X�ɂ��Ă�������")]
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
