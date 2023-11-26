using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //�J�[�h�̏����i�[
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

    

    //�I�΂ꂽ����
    private int _choiseNum;
    //�J��Ԃ����s����
    private int _loopcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    //�J�[�h���̂Ă�
    public void ThrowCard()
    {
        
            if (FazeManager.NowCardFaze == CardFaze.Throw)
            {
                //�R�D�̃J�[�h��S�Ċm�F
                for (int i = 1; i < 10; i++)
                {
                    //��D�ɂ���ꍇ�͎̂ĎD��
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
                //�R���h���[������܂ŌJ��Ԃ�
                while (_loopcount < 3)
                {
                    //1�`9�̒����烉���_���ɐ������擾
                    int _choiseNum = Random.Range(1, 10);
                    //�I�΂ꂽ�����ɑΉ�����J�[�h���R�D�ɂ���ꍇ�h���[���s��
                    if (GetChoiseCard(_choiseNum).state == CardState.Mountain)
                    {
                        //�R�D�����D��
                        GetChoiseCard(_choiseNum).state = CardState.Hand;
                        //�J�[�h�̃I�u�W�F�N�g����D�̈ʒu�ֈړ�
                        GetObjectChoiseCard(_choiseNum).transform.position = MoveToHandPos(_loopcount).transform.position;
                        //�J��Ԃ��񐔂��J�E���g
                        _loopcount++;
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


    //�I�΂ꂽ�J�[�h�̏����擾
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
            default: throw new System.ArgumentException("Invalid argument:����");
        }

    }

    //�I�΂ꂽ�J�[�h�̃Q�[���I�u�W�F�N�g���擾
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
            default: throw new System.ArgumentException("Invalid argument:����2");
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
