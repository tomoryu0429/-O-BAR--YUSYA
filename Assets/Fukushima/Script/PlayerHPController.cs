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
        //"HealthText"�̃R���|�[�l���g�ɃA�N�Z�X
        //(int)��float��ϊ����邽��
        _textobj.GetComponent<Text>().text = ((int)_currentHP).ToString();
        //HPSystem�̃X�N���v�g��HPDown()��2�̐��l�𑗂�
        _hpSystem.GetComponent<HPSystem>().HPDown(_currentHP, _maxHP);
        if (_currentHP < 0)
        {
            _currentHP = 0;
        }
    }*/
}
