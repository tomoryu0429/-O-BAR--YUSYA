using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace old
{


    /// <summary>
    /// �J�[�h�S�̂̋���
    /// </summary>
    public struct CardNumEachState
    {
        public int MountainNum, HandNum, GabageNum;

    }



    public class CardManager : MonoBehaviour
    {
        //�J�[�h�̏����i�[
        public GameObject _Cardprefab;  //�J�[�h�v���n�u

        public List<GameObject> deckList = new List<GameObject>();          //�f�b�L�̓��e�i���X�g�j

        List<FoodKinds> nowHandCardFoodKinds = new List<FoodKinds>();       //���̎�D�̐H�ޓ��e�i���X�g�j

        //��D�̈ʒu
        public GameObject _handPos1;
        public GameObject _handPos2;
        public GameObject _handPos3;

        //������̃J�[�h���\��������D�ʒu
        public GameObject _handPosCooked;

        private const int _deckMax = 30;                        //�f�b�L�̏������
        private int _deckNum = 9;                               //���݂̃f�b�L�̖����i�����l��9�j

        public FoodKinds[] _foodKinds = new FoodKinds[23];      //�H�ނ̎�ށi���X�g�j

        CardNumEachState _CNEstate;                             //enum CardNumEachState

        bool isUsableCardNumIncreasing = false;                 //�J�[�h�̎g�p�\�����������Ă����Ԃ��ǂ���

        //�I�΂ꂽ����
        private int _choiseNum;
        //�J��Ԃ����s����
        private int _loopcount = 0;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < _deckNum; i++)
            {
                CreateNewCard(i);
            }
        }

        // Update is called once per frame
        void Update()
        {
            GabageBackToMountain();
        }

        //�J�[�h�̎g�p�\�����������Ă����Ԃ��ǂ�����n��
        public bool getisUsableCardNumIncreasing()
        {
            return isUsableCardNumIncreasing;
        }

        //�J�[�h�̎g�p�\�����������Ă����Ԃ��ǂ�����ݒ�
        public void setisUsableCardNumIncreasing(bool which)
        {
            isUsableCardNumIncreasing = which;
        }

        //�V�����J�[�h���쐬���āA���X�g�ɓ����
        public void CreateNewCard(int foodkindsNum, CardState cs = CardState.Mountain)
        {
            //�v���n�u����I�u�W�F�N�g�𕡐�
            GameObject _CardObject = Instantiate(_Cardprefab);
            //���������J�[�h�I�u�W�F�N�g�̃J�[�h�R���|�[�l���g���擾
            Card _card = _CardObject.GetComponent<Card>();

            _card.state = cs;

            Debug.Log(foodkindsNum);

            //�����Ō��߂�ꂽ�H�ނ̃^�C�v�����蓖�Ă�
            _card.type = _foodKinds[foodkindsNum];
            //�������ꂽ�J�[�h�𒲗��ςݎ�D�̈ʒu�ɁB�����ȊO�̒ǉ��̏ꍇ�͎R�D�ɂ���
            _card.transform.position = _handPosCooked.transform.position;

            //���������I�u�W�F�N�g�����X�g�ɒǉ����Ă���
            deckList.Add(_CardObject);
        }

        //�J�[�h���̂Ă�
        public void ThrowCard()
        {
            //��D�̑S�ẴJ�[�h���̂Ă�
            foreach (GameObject obj in deckList)
            {
                Card _card = obj.GetComponent<Card>();
                if (_card.state == CardState.Hand)
                {
                    _card.state = CardState.Gabage;
                }
            }

            //�t�F�C�Y�E�^�[���̐i�s
            FazeManager.NowCardFaze = CardFaze.Draw;
            TurnManager.turnState = TurnState.HeroAttack;

            //�R�D�̃J�[�h��0�̏ꍇ�͎̂ĎD��S�ĎR�D�ɖ߂�
            if (getNowCardNum().MountainNum == 0) GabageBackToMountain();

        }

        //�J�[�h�̃h���[����
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
                        int _choiseNum = Random.Range(0, deckList.Count - 1);

                        Card _card = deckList[_choiseNum].GetComponent<Card>();
                        if (_card.state == CardState.Mountain)
                        {
                            //�R�D�����D��
                            _card.state = CardState.Hand;
                            //�J�[�h����D�̈ʒu�ֈړ�
                            deckList[_choiseNum].transform.position = MoveToHandPos(_loopcount).transform.position;
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

        //�̂ĎD�̑S�ẴJ�[�h���R�D��
        void GabageBackToMountain()
        {
            //�J�[�h��S�Ċm�F
            foreach (GameObject obj in deckList)
            {
                Card _card = obj.GetComponent<Card>();
                if (_card.state == CardState.Gabage)
                {
                    _card.state = CardState.Mountain;
                }
            }
        }

        //�����̍ޗ��J�[�h���̂Ă�
        public void WhenCookedCardThrow(FoodKinds fk)
        {
            foreach (GameObject obj in deckList)
            {
                Card _card = obj.GetComponent<Card>();
                if (_card.state == CardState.Hand)
                {
                    if (_card.type == fk)
                    {
                        //�J�[�h���n��
                        _card.state = CardState.Death;
                        break;
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

        //��D�O���̃J�[�h�^�C�v��n��
        public List<FoodKinds> getNowHandCardFoodKinds()
        {
            //�c���Ă���J�[�h�^�C�v�̃f�[�^���N���A
            nowHandCardFoodKinds.Clear();

            //�S�ẴJ�[�h�̒������D�̃J�[�h���擾���āA���̐H�ނ̎�ނ����X�g�ɕۑ�����
            foreach (GameObject obj in deckList)
            {
                Card _card = obj.GetComponent<Card>();
                if (_card.state == CardState.Hand)
                {
                    nowHandCardFoodKinds.Add(_card.type);
                }

            }

            //���X�g�̓��e��n��
            return nowHandCardFoodKinds;
        }

        //���݂̃J�[�h�����̊m�F
        public CardNumEachState getNowCardNum()
        {
            //�����̐��l�����Z�b�g
            _CNEstate.MountainNum = 0;
            _CNEstate.HandNum = 0;
            _CNEstate.GabageNum = 0;

            //�S�ẴJ�[�h���m�F���A���ꂼ��̖������J�E���g
            foreach (GameObject obj in deckList)
            {

                Card _card = obj.GetComponent<Card>();
                if (_card.state == CardState.Hand)
                {
                    _CNEstate.HandNum++;
                }
                else if (_card.state == CardState.Mountain)
                {
                    _CNEstate.MountainNum++;
                }
                else if (_card.state == CardState.Gabage)
                {
                    _CNEstate.GabageNum++;
                }

            }
            //�d��������Ԃ�
            return _CNEstate;
        }



    }

}