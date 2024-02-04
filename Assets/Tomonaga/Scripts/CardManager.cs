using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// �J�[�h�S�̂̋���
/// </summary>


public class CardManager : MonoBehaviour
{
    //�J�[�h�̏����i�[
    public GameObject _Cardprefab;  //�J�[�h�v���n�u
    
    public Dictionary<int, GameObject> deckDictionary = new Dictionary<int, GameObject>();

    public GameObject _handPos1;
    public GameObject _handPos2;
    public GameObject _handPos3;

    private const int _deckMax = 30;
    private int _deckNum = 9;
    
    public FoodKinds[] _foodKinds = new FoodKinds[12];




    //�I�΂ꂽ����
    private int _choiseNum;
    //�J��Ԃ����s����
    private int _loopcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < _deckNum;i++)
        {
            //�v���n�u����I�u�W�F�N�g�𕡐�
            GameObject _CardObject = Instantiate(_Cardprefab);
            //���������J�[�h�I�u�W�F�N�g�̃J�[�h�R���|�[�l���g���擾
            Card _card = _CardObject.GetComponent<Card>();
            
            _card.state = CardState.Mountain;
           
            _card.type = _foodKinds[i];
            

            //���������I�u�W�F�N�g�����X�g�ɒǉ����Ă���
            deckDictionary.Add(i, _CardObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GabageBackToMountain();
    }


    //�J�[�h���̂Ă�
    public void ThrowCard()
    {
        
         if (FazeManager.NowCardFaze == CardFaze.Throw)
         {
             //�R�D�̃J�[�h��S�Ċm�F
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
         }
        
      
    }

    public void DrawCard()
    {
        if (TurnManager.turnState == TurnState.Card)
        {
            if (FazeManager.NowCardFaze == CardFaze.Draw)
            {
                //�R���h���[������܂ŌJ��Ԃ�
                while (_loopcount < 3)
                {
                    //1�`9�̒����烉���_���ɐ������擾
                    int _choiseNum = Random.Range(0, _deckMax);
                    GameObject _cardObject;
                    if (deckDictionary.TryGetValue(_choiseNum, out _cardObject))
                    {
                        Card _card = _cardObject.GetComponent<Card>();
                        if (_card.state == CardState.Mountain)
                        {
                            //�R�D�����D��
                            _card.state = CardState.Hand;
                            //�J�[�h����D�̈ʒu�ֈړ�
                            _cardObject.transform.position = MoveToHandPos(_loopcount).transform.position;
                            //�J��Ԃ��񐔂��J�E���g
                            _loopcount++;
                        }

                    }
                }
                //�h���[���I���ΌJ��Ԃ��񐔂����Z�b�g
                _loopcount = 0;
                FazeManager.NowCardFaze = CardFaze.Selsect;
            }
            else
            {
                Debug.Log("Faze���h���[����Ȃ���");
            }
        }

    }   

    void GabageBackToMountain()
    {
        if(TurnManager.turnState == TurnState.End)
        {
            int MountainNum = 0;
            //�J�[�h��S�Ċm�F
            for (int i = 0; i < _deckNum; i++)
            {

                GameObject _cardObject;
                if (deckDictionary.TryGetValue(i, out _cardObject))
                {
                    Card _card = _cardObject.GetComponent<Card>();
                    if (_card.state == CardState.Mountain)
                    {
                        MountainNum++;
                    }

                }
            }

            Debug.Log(MountainNum);
            if(MountainNum == 0)
            {
                //�J�[�h��S�Ċm�F
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
    }




    //�h���[���ꂽ���Ԃɏ]����D�̈ړ�����擾
    GameObject MoveToHandPos(int _loopnum)
    {
        switch (_loopnum)
        {
            case 0: return _handPos1;
            case 1: return _handPos2;
            case 2: return _handPos3;
            default: throw new System.ArgumentException("Invalid argument:��D");
        }

    }




}
