using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// カード全体の挙動
/// </summary>
public struct CardNumEachState
{
   public int MountainNum, HandNum, GabageNum;

}





public class CardManager : MonoBehaviour
{
    //カードの情報を格納
    public GameObject _Cardprefab;  //カードプレハブ
    
    public List<GameObject> deckList = new List<GameObject>();

    List<FoodKinds> nowHandCardFoodKinds = new List<FoodKinds>();

    public GameObject _handPos1;
    public GameObject _handPos2;
    public GameObject _handPos3;
    public GameObject _handPosCooked;



    private const int _deckMax = 30;
    private int _deckNum = 9;
    
    public FoodKinds[] _foodKinds = new FoodKinds[23];

    CardNumEachState _CNEstate;

    bool isUsableCardNumIncreasing = false;


    //選ばれた数字
    private int _choiseNum;
    //繰り返しを行う回数
    private int _loopcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < _deckNum;i++)
        {
            CreateNewCard(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GabageBackToMountain();
    }

    public bool getisUsableCardNumIncreasing()
    {
        return isUsableCardNumIncreasing;
    }

    public void setisUsableCardNumIncreasing(bool which)
    {
        isUsableCardNumIncreasing = which;
    }

    public void CreateNewCard(int foodkindsNum,CardState cs = CardState.Mountain)
    {
        //プレハブからオブジェクトを複製
        GameObject _CardObject = Instantiate(_Cardprefab);
        //生成したカードオブジェクトのカードコンポーネントを取得
        Card _card = _CardObject.GetComponent<Card>();

        _card.state = cs;

        Debug.Log(foodkindsNum);

        _card.type = _foodKinds[foodkindsNum];

        _card.transform.position = _handPosCooked.transform.position;

        //生成したオブジェクトをリストに追加していく
        deckList.Add(_CardObject);
    }

    //カードを捨てる
    public void ThrowCard()
    {
       foreach(GameObject obj in deckList)
       {
          Card _card = obj.GetComponent<Card>();
          if (_card.state == CardState.Hand)
          {
              _card.state = CardState.Gabage;
          }
       }
        
         
         FazeManager.NowCardFaze = CardFaze.Draw;
         TurnManager.turnState = TurnState.HeroAttack;
        if (getNowCardNum().MountainNum == 0) GabageBackToMountain();
          
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
                    int _choiseNum = Random.Range(0, deckList.Count - 1);
                   
                    Card _card = deckList[_choiseNum].GetComponent<Card>();
                    if (_card.state == CardState.Mountain)
                    {
                        //山札から手札へ
                        _card.state = CardState.Hand;
                        //カードを手札の位置へ移動
                        deckList[_choiseNum].transform.position = MoveToHandPos(_loopcount).transform.position;
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

    void GabageBackToMountain()
    {
        //カードを全て確認
        foreach (GameObject obj in deckList)
        {
            Card _card = obj.GetComponent<Card>();
            if (_card.state == CardState.Gabage)
            {
                _card.state = CardState.Mountain;
            }   
        }
    }

    public void WhenCookedCardThrow(FoodKinds fk)
    {
        foreach (GameObject obj in deckList)
        {
            Card _card = obj.GetComponent<Card>();
            if(_card.state == CardState.Hand)
            {
                if(_card.type == fk)
                {
                    _card.state = CardState.Death;
                    break;
                }
            }
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

    //手札三枚のカードタイプを渡す
    public List<FoodKinds> getNowHandCardFoodKinds()
    {
        nowHandCardFoodKinds.Clear();

        foreach (GameObject obj in deckList)
        {
            Card _card = obj.GetComponent<Card>();
            if (_card.state == CardState.Hand)
            {
                nowHandCardFoodKinds.Add(_card.type);
            }
            
        }

        return nowHandCardFoodKinds;
    }

    //現在のカード枚数の確認
    public CardNumEachState getNowCardNum()
    {
        _CNEstate.MountainNum =0;
        _CNEstate.HandNum = 0;
        _CNEstate.GabageNum = 0;

        foreach (GameObject obj in deckList)
        {
          
              Card _card = obj.GetComponent<Card>();
              if (_card.state == CardState.Hand)
              {
                  _CNEstate.HandNum++;
              }
              else if(_card.state == CardState.Mountain)
              {
                  _CNEstate.MountainNum++;
              }
              else if (_card.state == CardState.Gabage)
              {
                  _CNEstate.GabageNum++;
              }
            
        }
        return _CNEstate;
    }



}
