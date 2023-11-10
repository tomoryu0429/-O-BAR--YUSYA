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
        //＝＝＝＝現在３枚同時に使うことになっているのでこれを１枚づつに変える＝＝＝＝//
        //山札のカードを全て確認
        for(int i = 1; i<10;i++)
        {
            //手札にある場合は捨て札に
            if(GetChoiseCard(i).state == CardState.Hand)
            {
                GetChoiseCard(i).state = CardState.Gabage;
            }
        }
    }

    //選ばれたカードの情報を取得
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
                throw new System.ArgumentException("Invalid argument:乱数");
        }

    }

}
