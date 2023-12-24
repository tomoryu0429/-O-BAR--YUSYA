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
    Cook,
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

    int TurnNum = 1;

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

        if (turnState == TurnState.Card && CardButton.activeSelf == false)
        {
            CardButton.SetActive(true);
        }
        else if(turnState != TurnState.Card && CardButton.activeSelf == true)
        {
            CardButton.SetActive(false);
        }

    }

    public�@void ProgressTurn()
    {
        if(turnState == TurnState.End)
        {
            turnState = TurnState.Card;
            AddTurnNum();
            
        }
        else if(turnState == TurnState.Card)
        {
            turnState += 2;
        }
        else
        {
            turnState++;
        }
      
    }

    public void AddTurnState()
    {
        turnState++;
    }


    void AddTurnNum()
    {
        TurnNum++;
    }
   
}
