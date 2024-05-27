using UnityEngine;

public class T_Player : MonoBehaviour
{

    [SerializeField] int _hpUpDown = 0;
    [Tooltip("減らしたい場合は数値をマイナスにしてください")]
    [SerializeField] int _ypDown = 15;
    //public static int _currentHP = 100;
    //public static int _currentYP = 100;Gamemanagerで修正予定
    public static int _currentDif = 0;
   // public GameObject _hpTextobj;
   // public GameObject _ypTextobj;
    public void Start()
    {

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
        //}HPber参照
    }

    //public void HPUpDown()
    //{
    //    _currentHP += _hpUpDown;
    //    Debug.Log($"HP + {_hpUpDown}");
    //}HPber参照

    //public void YPDown()
    //{
    //    _currentYP -= _ypDown;
    //    Debug.Log($"YP - {_ypDown}");
    //}HPber参照

    public void DefReset()
    {
        _currentDif = 0;
        Debug.Log("防御力がリセットされた");
    }

    //public void pAttack()
    //{
    //    YPDown();
    //    TurnManager.turnState = TurnState.EnemyAttack;
    //}HPber参照
}
