using System.Collections;
using System.Collections.Generic;
using Tani;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Syounin : MonoBehaviour
{
    [SerializeField] List<int> BuyGold = new List<int>();//���l
    [SerializeField] List<int> BuyGoldF = new List<int>();//�������l
    [SerializeField] List<int> SellGold = new List<int>();//���l
    [SerializeField] List<int> Percent = new List<int>();//�����m��
    [SerializeField] int rnd;//�m���v�Z�p

    [SerializeField] int Money;//�����Ă��邨���i���ϐ��j

    string aa;
    int AAid;
    int BBid;
    [SerializeField] Text Nametext;
    [SerializeField] Text Nametext2;
    [SerializeField] Text NametextF;
    [SerializeField] Text BuyText;
    [SerializeField] Text BuyText2;
    [SerializeField] Text BuyTextF;
    [SerializeField] Text MoneyText;
    //[SerializeField] Text SellText;
    //[SerializeField] Image image;
    /*
    public enum FoodName
    {
        GrilledFish,
        SashimiRice,
        FriedPork,
        Curry,
        FriedVegetables,
        Pancake,
        StrawberryParfait,
        ChocolateCrepe,
        FruitJelly,
        ShortCake,
        ChocolateCake,
    }
    */
    void Start()
    {
        CardData.ECardID Aid = EnumSystem.GetRandom<CardData.ECardID>();
        Debug.Log(Aid);
        //aa = a.ToString();
        AAid = (int)Aid;
        CardData.ECardID Bid = EnumSystem.GetRandom<CardData.ECardID>();
        BBid = (int)Bid;

        MoneyText.text = Money + " �~";
        //�����J�[�h�̊m��
        rnd = Random.Range(1, 100);
        if(rnd <= Percent[0])
        {
            NametextF.text = "���̉��Ă�";
            BuyTextF.text = "���l " + BuyGoldF[0] + " �~";
        }
        else if (rnd <= Percent[1])
        {
            NametextF.text = "�C�N��";
            BuyTextF.text = "���l " + BuyGoldF[1] + " �~";
        }
        else if (rnd <= Percent[2])
        {
            NametextF.text = "�Ƃ񂩂�";
            BuyTextF.text = "���l " + BuyGoldF[2] + " �~";
        }
        else if (rnd <= Percent[3])
        {
            NametextF.text = "�J���[";
            BuyTextF.text = "���l " + BuyGoldF[3] + " �~";
        }
        else if (rnd <= Percent[4])
        {
            NametextF.text = "����u��";
            BuyTextF.text = "���l " + BuyGoldF[4] + " �~";
        }
        else if (rnd <= Percent[5])
        {
            NametextF.text = "�p���P�[�L";
            BuyTextF.text = "���l " + BuyGoldF[5] + " �~";
        }
        else if (rnd <= Percent[6])
        {
            NametextF.text = "�������p�t�F";
            BuyTextF.text = "���l " + BuyGoldF[6] + " �~";
        }
        else if (rnd <= Percent[7])
        {
            NametextF.text = "�`���R���[�g�N���[�v";
            BuyTextF.text = "���l " + BuyGoldF[7] + " �~";
        }
        else if (rnd <= Percent[8])
        {
            NametextF.text = "�ʕ��[���[";
            BuyTextF.text = "���l " + BuyGoldF[8] + " �~";
        }
        else if (rnd <= Percent[9])
        {
            NametextF.text = "�V���[�g�P�[�L";
            BuyTextF.text = "���l " + BuyGoldF[9] + " �~";
        }
        else if (rnd <= Percent[10])
        {
            NametextF.text = "�`���R���[�g�P�[�L";
            BuyTextF.text = "���l " + BuyGoldF[10] + " �~";
        }
        //Debug.Log(b);
        //Debug.Log(BuyGold[0]);
        switch (AAid)
        {
            case 0:
                Nametext.text = "��";
                BuyText.text = "���l " + BuyGold[0] + " �~";
                break;
            case 1:
                Nametext.text = "��";
                BuyText.text = "���l " + BuyGold[1] + " �~";
                break;
            case 2:
                Nametext.text = "�L�m�R";
                BuyText.text = "���l " + BuyGold[2] + " �~";
                break;
            case 3:
                Nametext.text = "�g�}�g";
                BuyText.text = "���l " + BuyGold[3] + " �~";
                break;
            case 4:
                Nametext.text = "�ʂ˂�";
                BuyText.text = "���l " + BuyGold[4] + " �~";
                break;
            case 5:
                Nametext.text = "����";
                BuyText.text = "���l " + BuyGold[5] + " �~";
                break;
            case 6:
                Nametext.text = "�[���`��";
                BuyText.text = "���l " + BuyGold[6] + " �~";
                break;
            case 7:
                Nametext.text = "����";
                BuyText.text = "���l " + BuyGold[7] + " �~";
                break;
            case 8:
                Nametext.text = "�C�`�S";
                BuyText.text = "���l " + BuyGold[8] + " �~";
                break;
            case 9:
                Nametext.text = "�͂��݂�";
                BuyText.text = "���l " + BuyGold[9] + " �~";
                break;
            case 10:
                Nametext.text = "�~���N";
                BuyText.text = "���l " + BuyGold[10] + " �~";
                break;
            case 11:
                Nametext.text = "�`���R";
                BuyText.text = "���l " + BuyGold[11] + " �~";
                break;
        }
        switch (BBid)
        {
            case 0:
                Nametext2.text = "��";
                BuyText2.text = "���l " + BuyGold[0] + " �~";
                break;
            case 1:
                Nametext2.text = "��";
                BuyText2.text = "���l " + BuyGold[1] + " �~";
                break;
            case 2:
                Nametext2.text = "�L�m�R";
                BuyText2.text = "���l " + BuyGold[2] + " �~";
                break;
            case 3:
                Nametext2.text = "�g�}�g";
                BuyText2.text = "���l " + BuyGold[3] + " �~";
                break;
            case 4:
                Nametext2.text = "�ʂ˂�";
                BuyText2.text = "���l " + BuyGold[4] + " �~";
                break;
            case 5:
                Nametext2.text = "����";
                BuyText2.text = "���l " + BuyGold[5] + " �~";
                break;
            case 6:
                Nametext2.text = "�[���`��";
                BuyText2.text = "���l " + BuyGold[6] + " �~";
                break;
            case 7:
                Nametext2.text = "����";
                BuyText2.text = "���l " + BuyGold[7] + " �~";
                break;
            case 8:
                Nametext2.text = "�C�`�S";
                BuyText2.text = "���l " + BuyGold[8] + " �~";
                break;
            case 9:
                Nametext2.text = "�͂��݂�";
                BuyText2.text = "���l " + BuyGold[9] + " �~";
                break;
            case 10:
                Nametext2.text = "�~���N";
                BuyText2.text = "���l " + BuyGold[10] + " �~";
                break;
            case 11:
                Nametext2.text = "�`���R";
                BuyText2.text = "���l " + BuyGold[11] + " �~";
                break;
        }
    }

    void Update()
    {
        
    }
    
}
