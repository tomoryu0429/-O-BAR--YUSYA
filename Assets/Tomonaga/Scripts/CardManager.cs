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
    
    public Dictionary<int, GameObject> deckDictionary = new Dictionary<int, GameObject>();

    List<FoodKinds> nowHandCardFoodKinds = new List<FoodKinds>();

    public GameObject _handPos1;
    public GameObject _handPos2;
    public GameObject _handPos3;

    private const int _deckMax = 30;
    private int _deckNum = 9;
    
    public FoodKinds[] _foodKinds = new FoodKinds[12];

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
            //プレハブからオブジェクトを複製
            GameObject _CardObject = Instantiate(_Cardprefab);
            //生成したカードオブジェクトのカードコンポーネントを取得
            Card _card = _CardObject.GetComponent<Card>();
            
            _card.state = CardState.Mountain;
           
            _card.type = _foodKinds[i];
            

            //生成したオブジェクトをリストに追加していく
            deckDictionary.Add(i, _CardObject);
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



    //カードを捨てる
    public void ThrowCard()
    {
        //山札のカードを全て確認
        for (int i = 0; i < _deckNum; i++)
        {
        
             GameObject _cardObject;
             if (deckDictionary.TryGetValue(i, out _cardObject))
             {
                 Card _card = _cardObject.GetComponent<Card>();
                 if (_card.state == CardState.Hand)
                 {
                     _card.state = CardState.Gabage;
                 }
             
             }
        }
         
         FazeManager.NowCardFaze = CardFaze.Draw;
         TurnManager.turnState = TurnState.HeroAttack;
         GabageBackToMountain();
          
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
                    int _choiseNum = Random.Range(0, _deckMax);
                    GameObject _cardObject;
                    if (deckDictionary.TryGetValue(_choiseNum, out _cardObject))
                    {
                        Card _card = _cardObject.GetComponent<Card>();
                        if (_card.state == CardState.Mountain)
                        {
                            //山札から手札へ
                            _card.state = CardState.Hand;
                            //カードを手札の位置へ移動
                            _cardObject.transform.position = MoveToHandPos(_loopcount).transform.position;
                            //繰り返し回数をカウント
                            _loopcount++;
                        }

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
       
        if(getNowCardNum().MountainNum == 0)
        {
            //カードを全て確認
            for (int i = 0; i < _deckNum; i++)
            {
                GameObject _cardObject;
                if (deckDictionary.TryGetValue(i, out _cardObject))
                {
                    Card _card = _cardObject.GetComponent<Card>();
                    if (_card.state == CardState.Gabage)
                    {
                        _card.state = CardState.Mountain;
                    }
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

        for (int i = 0; i < _deckNum; i++)
        {
            GameObject _cardObject;
            if (deckDictionary.TryGetValue(i, out _cardObject))
            {
                Card _card = _cardObject.GetComponent<Card>();
                if (_card.state == CardState.Hand)
                {
                    nowHandCardFoodKinds.Add(_card.type);
                }
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

        for (int i = 0; i < _deckNum; i++)
        {
            GameObject _cardObject;
            if (deckDictionary.TryGetValue(i, out _cardObject))
            {
                Card _card = _cardObject.GetComponent<Card>();
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
        }
        return _CNEstate;
    }



}
