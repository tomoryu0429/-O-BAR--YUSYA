using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //カードの情報を格納
    public Card _card01;
    public GameObject _card1;
    public Card _card02;
    public GameObject _card2;
    public Card _card03;
    public GameObject _card3;
    public Card _card04;
    public GameObject _card4;
    public Card _card05;
    public GameObject _card5;
    public Card _card06;
    public GameObject _card6;
    public Card _card07;
    public GameObject _card7;
    public Card _card08;
    public GameObject _card8;
    public Card _card09;
    public GameObject _card9;
    public GameObject _handPos1;
    public GameObject _handPos2;
    public GameObject _handPos3;

    

    //選ばれた数字
    private int _choiseNum;
    //繰り返しを行う回数
    private int _loopcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //カードを捨てる
    public void ThrowCard()
    {
        
            if (FazeManager.NowCardFaze == CardFaze.Throw)
            {
                //山札のカードを全て確認
                for (int i = 1; i < 10; i++)
                {
                    //手札にある場合は捨て札に
                    if (GetChoiseCard(i).state == CardState.Hand)
                    {
                        GetChoiseCard(i).state = CardState.Gabage;
                    }
                }
            FazeManager.NowCardFaze = CardFaze.Draw;
            TurnManager.turnState = TurnState.HeroAttack;
            }
        
      
    }

    public void DrawCard()
    {
        if (TurnManager.turnState == TurnState.Card)
        {
            if (FazeManager.NowCardFaze == CardFaze.Draw)
            {
                //３枚ドローをするまで繰り返し
                while (_loopcount < 3)
                {
                    //1～9の中からランダムに数字を取得
                    int _choiseNum = Random.Range(1, 10);
                    //選ばれた数字に対応するカードが山札にある場合ドローを行う
                    if (GetChoiseCard(_choiseNum).state == CardState.Mountain)
                    {
                        //山札から手札へ
                        GetChoiseCard(_choiseNum).state = CardState.Hand;
                        //カードのオブジェクトを手札の位置へ移動
                        GetObjectChoiseCard(_choiseNum).transform.position = MoveToHandPos(_loopcount).transform.position;
                        //繰り返し回数をカウント
                        _loopcount++;
                    }
                }
                //ドローが終われば繰り返し回数をリセット
                _loopcount = 0;
                FazeManager.NowCardFaze = CardFaze.Selsect;
            }
            else
            {
                Debug.Log("Fazeがドローじゃないよ");
            }
        }

    }


    //選ばれたカードの情報を取得
    public Card GetChoiseCard(int ChoiseNum)
    {
        switch (ChoiseNum)
        {
            case 1: return _card01;
            case 2: return _card02;
            case 3: return _card03;
            case 4: return _card04;
            case 5: return _card05;
            case 6: return _card06;
            case 7: return _card07;
            case 8: return _card08;
            case 9: return _card09;
            default: throw new System.ArgumentException("Invalid argument:乱数");
        }

    }

    //選ばれたカードのゲームオブジェクトを取得
    GameObject GetObjectChoiseCard(int ChoiseNum)
    {
        switch (ChoiseNum)
        {
            case 1: return _card1;
            case 2: return _card2;
            case 3: return _card3;
            case 4: return _card4;
            case 5: return _card5;
            case 6: return _card6;
            case 7: return _card7;
            case 8: return _card8;
            case 9: return _card9;
            default: throw new System.ArgumentException("Invalid argument:乱数2");
        }

    }

    //ドローされた順番に従い手札の移動先を取得
    GameObject MoveToHandPos(int _loopnum)
    {
        switch (_loopnum)
        {
            case 0: return _handPos1;
            case 1: return _handPos2;
            case 2: return _handPos3;
            default: throw new System.ArgumentException("Invalid argument:手札");
        }

    }




}
