using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カード関係の見た目の管理
/// </summary>


public class CardBoardManager : MonoBehaviour
{
    public static int _MountainCardNum = 9;     //山札の枚数の
    public static int _HandCardNum = 0;         //手札の枚数の
    public static int _GabageCardNum = 0;       //捨て札の枚数
    public GameObject _MountainCard;            //山札
    public GameObject _GabageCard;              //捨て札
    public Text valueM;
    public Text valueH;
    public Text valueG;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        valueM.text = "山札: " + _MountainCardNum.ToString();
        valueH.text = "手札: " + _HandCardNum.ToString();
        valueG.text = "捨て札: " + _GabageCardNum.ToString();
        GabageZoneCtrl();
        MountainZoneCtrl();
    }

    //デバッグ用リセット
    public void Reset()
    {
        _MountainCardNum = 9;
        _HandCardNum = 0;
        _GabageCardNum = 0;
    }



    //山札表示の制御
    void MountainZoneCtrl()
    {
        //山札の枚数が0で山札が表示されている時、山札の表示を消す
        if(_MountainCardNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        //山札の枚数が0ではなく、山札が表示されていない時、山札を表示する
        else if(_MountainCardNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //捨て札表示の制御
    void GabageZoneCtrl()
    {
        //捨て札が0で捨て札が表示されている時、捨て札の表示を消す
        if (_GabageCardNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        //捨て札が0ではなく、捨て札が表示されていない時、捨て札を表示する
        else if (_GabageCardNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

    //要修正
    //カードのドロー
    public void Draw()
    {
        if (TurnManager.turnState == TurnState.Card)
        {
            if (FazeManager.NowCardFaze == CardFaze.Draw)
            {
                //山札が0枚ではない、もしくは手札が３枚でないときドローできる
                if (_MountainCardNum > 0 || _HandCardNum < 3)
                {
                    _MountainCardNum -= 3;
                    _HandCardNum += 3;
                    
                }
                else
                {
                    Debug.Log("山札がないか手札がいっぱいだよ");
                }
            }
            else
            {
                Debug.Log("Fazeがドローではないよ");
            }
        }
       
    }

    //要修正
    //カードを捨てる
    public void ThrowCard()
    {
        if (FazeManager.NowCardFaze == CardFaze.Throw)
        {
            //手札が0出ない時に実行可能
            if (_HandCardNum > 0)
            {
                _HandCardNum -= 3;
                _GabageCardNum += 3;
               
            }
            else
            {
                Debug.Log("手札がないよ");
            }
        }
        else
        {
            Debug.Log("Fazeがスローではないよ");
        }
            
    }

}
