using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カード関係の見た目の管理
/// </summary>


public class CardBoardManager : MonoBehaviour
{
    public GameObject _MountainCard;            //山札
    public GameObject _GabageCard;              //捨て札
    public Text valueM;
    public Text valueH;
    public Text valueG;
    public CardManager cardManager;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        valueM.text = "山札: " + cardManager.getNowCardNum().MountainNum.ToString();
        valueH.text = "手札: " + cardManager.getNowCardNum().HandNum.ToString();
        valueG.text = "捨て札: " + cardManager.getNowCardNum().GabageNum.ToString();
        GabageZoneCtrl();
        MountainZoneCtrl();
    }

    //デバッグ用リセット
    public void Reset()
    {
        //_MountainCardNum = cardManager.getNowCardNum().MountainNum;
        //_HandCardNum = cardManager.getNowCardNum().HandNum;
        //_GabageCardNum = cardManager.getNowCardNum().GabageNum;
    }



    //山札表示の制御
    void MountainZoneCtrl()
    {
        //山札の枚数が0で山札が表示されている時、山札の表示を消す
        if(cardManager.getNowCardNum().MountainNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        //山札の枚数が0ではなく、山札が表示されていない時、山札を表示する
        else if(cardManager.getNowCardNum().MountainNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //捨て札表示の制御
    void GabageZoneCtrl()
    {
        //捨て札が0で捨て札が表示されている時、捨て札の表示を消す
        if (cardManager.getNowCardNum().GabageNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        //捨て札が0ではなく、捨て札が表示されていない時、捨て札を表示する
        else if (cardManager.getNowCardNum().GabageNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

   

}
