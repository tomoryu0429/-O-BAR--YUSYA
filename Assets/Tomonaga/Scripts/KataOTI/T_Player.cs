using UnityEngine;

public class T_Player : MonoBehaviour
{

    [SerializeField] int _hpUpDown = 0;
    [Tooltip("���炵�����ꍇ�͐��l���}�C�i�X�ɂ��Ă�������")]
    [SerializeField] int _ypDown = 15;
    //public static int _currentHP = 100;
    //public static int _currentYP = 100;Gamemanager�ŏC���\��
    public static int _currentDif = 0;
   // public GameObject _hpTextobj;
   // public GameObject _ypTextobj;
    public void Start()
    {

    }

    public void Update()
    {
        //"HealthText"�̃R���|�[�l���g�ɃA�N�Z�X
        //(int)��float��ϊ����邽��
        //  _hpTextobj.GetComponent<Text>().text = ((int)_currentHP).ToString();


        //"HealthText"�̃R���|�[�l���g�ɃA�N�Z�X
        //(int)��float��ϊ����邽��
        // _ypTextobj.GetComponent<Text>().text = ((int)_currentYP).ToString();
        //�l���˂������Ȃ��悤��
        //if (_currentHP > _maxHP)
        //{
        //    _currentHP = _maxHP;
        //}
        //if (_currentYP > _maxYP)
        //{
        //    _currentYP = _maxYP;
        //}
        //if (_currentYP <= 0)
        //{
        //    _currentYP = 0;
        //}HPber�Q��
    }

    //public void HPUpDown()
    //{
    //    _currentHP += _hpUpDown;
    //    Debug.Log($"HP + {_hpUpDown}");
    //}HPber�Q��

    //public void YPDown()
    //{
    //    _currentYP -= _ypDown;
    //    Debug.Log($"YP - {_ypDown}");
    //}HPber�Q��

    public void DefReset()
    {
        _currentDif = 0;
        Debug.Log("�h��͂����Z�b�g���ꂽ");
    }

    //public void pAttack()
    //{
    //    YPDown();
    //    TurnManager.turnState = TurnState.EnemyAttack;
    //}HPber�Q��
}
