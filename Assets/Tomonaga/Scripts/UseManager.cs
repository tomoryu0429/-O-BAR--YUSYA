using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseManager : MonoBehaviour
{
    public Card _card01;
    public Card _card02;
    public Card _card03;
    public Card _card04;
    public Card _card05;
    public Card _card06;
    public Card _card07;
    public Card _card08;
    public Card _card09;

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


    public void UseCard()
    {
        for(int i = 1; i<10;i++)
        {
           if(GetChoiseCard(i).state == State.Hand)
            {
                GetChoiseCard(i).state = State.Gabage;
            }
        }
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

}
