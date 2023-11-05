using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{

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

    private int _choiseNum;
    private int _loopcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        while(_loopcount <3)
        {
            int _choiseNum = Random.Range(1, 10);
            if (GetChoiseCard(_choiseNum).state == State.Mountain)
            {
                GetChoiseCard(_choiseNum).state = State.Hand;
                GetObjectChoiseCard(_choiseNum).transform.position= MoveToHandPos(_loopcount).transform.position;
                _loopcount++;
            }

        }
        _loopcount = 0;
      
    }

    Card GetChoiseCard(int ChoiseNum)
    {
        switch (ChoiseNum)
        {
            case 1:
                return _card01;
            case 2:
                return _card02;
            case 3:
                return _card03;
            case 4:
                return _card04;
            case 5:
                return _card05;
            case 6:
                return _card06;
            case 7:
                return _card07;
            case 8:
                return _card08;
            case 9:
                return _card09;
            default:
                throw new System.ArgumentException("Invalid argument:—”");
        }

    }

    GameObject GetObjectChoiseCard(int ChoiseNum)
    {
        switch (ChoiseNum)
        {
            case 1:
                return _card1;
            case 2:
                return _card2;
            case 3:
                return _card3;
            case 4:
                return _card4;
            case 5:
                return _card5;
            case 6:
                return _card6;
            case 7:
                return _card7;
            case 8:
                return _card8;
            case 9:
                return _card9;
            default:
                throw new System.ArgumentException("Invalid argument:—”2");
        }

    }

    GameObject MoveToHandPos(int _loopnum )
    {
        switch (_loopnum)
        {
        @@case 0:
                return _handPos1;
            case 1:
                return _handPos2;
            case 2:
                return _handPos3;
            default:
                throw new System.ArgumentException("Invalid argument:ŽèŽD");
        }

    }

}
