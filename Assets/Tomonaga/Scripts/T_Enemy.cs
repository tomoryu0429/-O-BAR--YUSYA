using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// α用の敵のスクリプト。マスターでは使わない
/// </summary>



public class T_Enemy : MonoBehaviour
{
    public int maxHp;
    public int Hp;
    public int atk;

    


    // Start is called before the first frame update
    void Start()
    {
        Hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp<= 0)
        {
            Debug.Log("敵死亡");
            this.gameObject.SetActive(false);
        }
    }

    //public void eAttack()
    //{
    //    T_Player._currentHP -= atk - T_Player._currentDif;
    //    TurnManager.turnState = TurnState.End;
    //}HPber参照

    public void receiveDamage()
    {
        Hp -= 1;
       
    }




}
