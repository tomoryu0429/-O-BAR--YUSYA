using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CardBoardManager : MonoBehaviour
{
    public static int _MountainCardNum = 9;
    public static int _HandCardNum = 0;
    public static int _GabageCardNum = 0;
    public GameObject _MountainCard;
    public GameObject _GabageCard;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    //捨て札表示の制御
    void GabageZoneCtrl()
    {
        if(_MountainCardNum == 0 && _MountainCard.activeSelf)
        {
            _MountainCard.SetActive(false);
        }
        else if(_MountainCardNum != 0 && !_MountainCard.activeSelf)
        {
            _MountainCard.SetActive(true);
        }
    }

    //山札表示の制御
    void MountainZoneCtrl()
    {
        if (_GabageCardNum == 0 && _GabageCard.activeSelf)
        {
            _GabageCard.SetActive(false);
        }
        else if (_GabageCardNum != 0 && !_GabageCard.activeSelf)
        {
            _GabageCard.SetActive(true);
        }
    }

    //要修正
    //カードのドロー
    public void Draw()
    {
        if(_MountainCardNum > 0 || _HandCardNum <3)
        {
            _MountainCardNum -= 3;
            _HandCardNum += 3;
            Debug.Log("山札:"+ _MountainCardNum);
            Debug.Log("手札:" + _HandCardNum);
        }
        else
        {
            Debug.Log("山札がないか手札がいっぱいだよ");
        }
    }

    //要修正
    //カードの使用
    public void UseCard()
    {
        if(_HandCardNum >0)
        {
            _HandCardNum -= 3;
            _GabageCardNum += 3;
            Debug.Log("捨て札:" + _GabageCardNum);
            Debug.Log("手札:" + _HandCardNum);
        }
        else
        {
            Debug.Log("手札がないよ");
        }
    }

}
