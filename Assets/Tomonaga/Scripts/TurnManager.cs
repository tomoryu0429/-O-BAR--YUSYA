using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �^�[���̊Ǘ�
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
        TurnText.text = "���݂̃^�[���̏�: " + turnState.ToString();
        TurnNumText.text = "���݂̃^�[����: " + TurnNum.ToString();

        //�e�X�g�p�{�^���̕\��
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

    //�^�[�����i��
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

    //�^�[�����i��
     public void AddTurnState()
    {
        turnState++;
    }

    //�^�[�����J�E���g�i�e�X�g�p�j
    void AddTurnNum()
    {
        TurnNum++;
    }
   
}
