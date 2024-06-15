using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using old;

public class CookMenu : MonoBehaviour
{
    public GameObject Brind;            //�I���ł��Ȃ����j���[�������Ȃ��悤�ɂ���u���C���h
    public FoodKinds thisFood;          //���̃��j���[���S�����闿���̎��

    public int MaterialNum ;            //�ޗ��̐��i�C���X�y�N�^�[�r���[�Őݒ�j

    bool[] ishavingMaterial = new bool[3] { false, false, false };  //���Ɏ����Ă���ޗ��̏��
    
    public FoodKinds[] MaterialFood = new FoodKinds[3];             //�ޗ��̐H��

    public CardManager cardManager;                                 //�J�[�h�}�l�[�W���[�i�X�N���v�g�j
 

    // Start is called before the first frame update
    void Start()
    {
       
        resetishavingMaterial();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�u���C���h�̐ݒ�
    public void setBrindState()
    {
        //�ޗ��������Ă��邩�ǂ����̃��Z�b�g
        resetishavingMaterial();

        //���݂̎�D�̐H�ނ̎�ނ��擾
        List<FoodKinds> foodKinds = cardManager.getNowHandCardFoodKinds();

        //�擾������ނƒ����̂��߂ɕK�v�ȍޗ��̎�ނ��������邩�̊m�F
        for(int i = 0; i < MaterialNum; i++)
        {
            for(int j = 0;j< foodKinds.Count; j++)
            {
                if (MaterialFood[i] == foodKinds[j])
                {
                    ishavingMaterial[i] = true;
                    break;
                }
            }
        }
        //�������Ă��Ȃ��ꍇ�̓u���C���h��t����
        Brind.SetActive(!isAllhavingTrue());
    }

    //�ޗ��������Ă��邩�ǂ����̃��Z�b�g
    void resetishavingMaterial()
    {
        for (int i = 0; i < MaterialNum; i++)
        {
            ishavingMaterial[i] = false; // �����l��false�Œǉ�
        }
    }

    //�S�Ă̍ޗ��������Ă���ꍇ�ATrue��Ԃ�
    bool isAllhavingTrue()
    {
        for (int i = 0; i < MaterialNum;i++)
        {
            if (ishavingMaterial[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    //�����̏���
    public void CookFunc()
    {
        //�ޗ��̐H�ނ��̂Ă�
        for (int i = 0; i < MaterialNum; i++)
        {
            cardManager.WhenCookedCardThrow(MaterialFood[i]);
        }

        //���̃��j���[�̗����̔ԍ�����
        int foodNum = (int)thisFood;

        //�V�����������s��
        cardManager.CreateNewCard(foodNum,CardState.Hand);
    }

}
