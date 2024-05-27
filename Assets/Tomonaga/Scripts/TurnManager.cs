using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ターンの管理
/// </summary>

public enum TurnState
{
    Card,
    HeroAttack,
    EnemyAttack,
    End,
}


public class TurnManager : MonoBehaviour
{
    public static TurnState turnState;

    public Text TurnText;
    public Text TurnNumText;

    public GameObject CardButton;
    public GameObject HeroAttackButton;
    public GameObject EnemyAttackButton;


    protected int TurnNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        turnState = TurnState.Card;
    }

    // Update is called once per frame
    void Update()
    {
        TurnText.text = "現在のターンの状況: " + turnState.ToString();
        TurnNumText.text = "現在のターン数: " + TurnNum.ToString();

        //テスト用ボタンの表示
        if (turnState == TurnState.Card && CardButton.activeSelf == false)
        {
            CardButton.SetActive(true);
        }
        else if(turnState != TurnState.Card && CardButton.activeSelf == true)
        {
            CardButton.SetActive(false);
        }
        if (turnState == TurnState.HeroAttack && HeroAttackButton.activeSelf == false)
        {
            HeroAttackButton.SetActive(true);
        }
        else if (turnState != TurnState.HeroAttack && HeroAttackButton.activeSelf == true)
        {
            HeroAttackButton.SetActive(false);
        }
        if (turnState == TurnState.EnemyAttack && EnemyAttackButton.activeSelf == false)
        {
            EnemyAttackButton.SetActive(true);
        }
        else if (turnState != TurnState.EnemyAttack && EnemyAttackButton.activeSelf == true)
        {
            EnemyAttackButton.SetActive(false);
        }

    }

    //ターンが進む
    public void ProgressTurn()
    {
        if(turnState == TurnState.End)
        {
            turnState = TurnState.Card;
            AddTurnNum();
        }
        else
        {
            turnState++;
        }
      
    }

    //ターンが進む
     public void AddTurnState()
    {
        turnState++;
    }

    //ターン数カウント（テスト用）
    void AddTurnNum()
    {
        TurnNum++;
    }
   
}
