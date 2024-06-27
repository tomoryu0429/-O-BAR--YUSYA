using System.Collections;
using System.Collections.Generic;
using Tani;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using R3;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BuySyounin : MonoBehaviour
{
    [SerializeField] List<int> BuyGold = new List<int>();//���l
    [SerializeField] List<int> BuyGoldF = new List<int>();//�������l
    [SerializeField] List<int> SellGold = new List<int>();//���l
    [SerializeField] List<int> Percent = new List<int>();//�����m��
    List<CardData> Data = new List<CardData>();//�J�[�h�̑S�f�[�^���擾���邽�߂̂���
    [SerializeField] int rnd;//�m���v�Z�p

    //for���Ɏg�p�����p�̕ϐ�
    int AAid;
    int BBid;
    int Number;

    bool SozaiA = true;
    bool SozaiB = true;
    bool Food = true;

    [SerializeField] Text Nametext;
    [SerializeField] Text Nametext2;
    [SerializeField] Text NametextF;
    [SerializeField] Text BuyText;
    [SerializeField] Text BuyText2;
    [SerializeField] Text BuyTextF;
    [SerializeField] Text MoneyText;
    //[SerializeField] Text SellText;
    //[SerializeField] Image image;

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
    
    void Start()
    {
        CardData.ECardID Aid = EnumSystem.GetRandom<CardData.ECardID>();
        Debug.Log(Aid);
        AAid = (int)Aid;
        CardData.ECardID Bid = EnumSystem.GetRandom<CardData.ECardID>();
        BBid = (int)Bid;
        /*
        for(int i = 0;i < (int)CardData.ECardID.Max; i++)
        {
            Data.Add(PlayerData.Instance.CardManager.GetCardData((CardData.ECardID)i));
        }
        */
        //�������̎擾
        PlayerData.Instance
                  .ReactiveProperty_Money
                  .Subscribe((money) => { MoneyText.text = money.ToString(); })
                  .AddTo(this);

        //�����J�[�h�̊m��
        rnd = Random.Range(1, 100);

        if(rnd <= Percent[0])
        {
            Number = 0;
            NametextF.text = "���̉��Ă�";
            BuyTextF.text = "���l " + BuyGoldF[0] + " �~";
        }
        else if (rnd <= Percent[1])
        {
            Number = 1;
            NametextF.text = "�C�N��";
            BuyTextF.text = "���l " + BuyGoldF[1] + " �~";
        }
        else if (rnd <= Percent[2])
        {
            Number = 2;
            NametextF.text = "�Ƃ񂩂�";
            BuyTextF.text = "���l " + BuyGoldF[2] + " �~";
        }
        else if (rnd <= Percent[3])
        {
            Number = 3;
            NametextF.text = "�J���[";
            BuyTextF.text = "���l " + BuyGoldF[3] + " �~";
        }
        else if (rnd <= Percent[4])
        {
            Number = 4;
            NametextF.text = "����u��";
            BuyTextF.text = "���l " + BuyGoldF[4] + " �~";
        }
        else if (rnd <= Percent[5])
        {
            Number = 5;
            NametextF.text = "�p���P�[�L";
            BuyTextF.text = "���l " + BuyGoldF[5] + " �~";
        }
        else if (rnd <= Percent[6])
        {
            Number = 6;
            NametextF.text = "�������p�t�F";
            BuyTextF.text = "���l " + BuyGoldF[6] + " �~";
        }
        else if (rnd <= Percent[7])
        {
            Number = 7;
            NametextF.text = "�`���R���[�g�N���[�v";
            BuyTextF.text = "���l " + BuyGoldF[7] + " �~";
        }
        else if (rnd <= Percent[8])
        {
            Number = 8;
            NametextF.text = "�ʕ��[���[";
            BuyTextF.text = "���l " + BuyGoldF[8] + " �~";
        }
        else if (rnd <= Percent[9])
        {
            Number = 9;
            NametextF.text = "�V���[�g�P�[�L";
            BuyTextF.text = "���l " + BuyGoldF[9] + " �~";
        }
        else if (rnd <= Percent[10])
        {
            Number = 10;
            NametextF.text = "�`���R���[�g�P�[�L";
            BuyTextF.text = "���l " + BuyGoldF[10] + " �~";
        }

        //Debug.Log(b);
        //Debug.Log(BuyGold[0]);


        switch (Aid)
        {
            case CardData.ECardID.Meet:
                Nametext.text = "��";
                BuyText.text = "���l " + BuyGold[0] + " �~";
                break;
            case CardData.ECardID.Fish:
                Nametext.text = "��";
                BuyText.text = "���l " + BuyGold[1] + " �~";
                break;
            case CardData.ECardID.Mash:
                Nametext.text = "�L�m�R";
                BuyText.text = "���l " + BuyGold[2] + " �~";
                break;
            case CardData.ECardID.Tomato:
                Nametext.text = "�g�}�g";
                BuyText.text = "���l " + BuyGold[3] + " �~";
                break;
            case CardData.ECardID.Onion:
                Nametext.text = "�ʂ˂�";
                BuyText.text = "���l " + BuyGold[4] + " �~";
                break;
            case CardData.ECardID.Rice:
                Nametext.text = "����";
                BuyText.text = "���l " + BuyGold[5] + " �~";
                break;
            case CardData.ECardID.Zer:
                Nametext.text = "�[���`��";
                BuyText.text = "���l " + BuyGold[6] + " �~";
                break;
            case CardData.ECardID.Flour:
                Nametext.text = "����";
                BuyText.text = "���l " + BuyGold[7] + " �~";
                break;
            case CardData.ECardID.Strawberry:
                Nametext.text = "�C�`�S";
                BuyText.text = "���l " + BuyGold[8] + " �~";
                break;
            case CardData.ECardID.Honey:
                Nametext.text = "�͂��݂�";
                BuyText.text = "���l " + BuyGold[9] + " �~";
                break;
            case CardData.ECardID.Milk:
                Nametext.text = "�~���N";
                BuyText.text = "���l " + BuyGold[10] + " �~";
                break;
            case CardData.ECardID.Choco:
                Nametext.text = "�`���R";
                BuyText.text = "���l " + BuyGold[11] + " �~";
                break;
        }

        switch (Bid)
        {
            case CardData.ECardID.Meet:
                Nametext2.text = "��";
                BuyText2.text = "���l " + BuyGold[0] + " �~";
                break;
            case CardData.ECardID.Fish:
                Nametext2.text = "��";
                BuyText2.text = "���l " + BuyGold[1] + " �~";
                break;
            case CardData.ECardID.Mash:
                Nametext2.text = "�L�m�R";
                BuyText2.text = "���l " + BuyGold[2] + " �~";
                break;
            case CardData.ECardID.Tomato:
                Nametext2.text = "�g�}�g";
                BuyText2.text = "���l " + BuyGold[3] + " �~";
                break;
            case CardData.ECardID.Onion:
                Nametext2.text = "�ʂ˂�";
                BuyText2.text = "���l " + BuyGold[4] + " �~";
                break;
            case CardData.ECardID.Rice:
                Nametext2.text = "����";
                BuyText2.text = "���l " + BuyGold[5] + " �~";
                break;
            case CardData.ECardID.Zer:
                Nametext2.text = "�[���`��";
                BuyText2.text = "���l " + BuyGold[6] + " �~";
                break;
            case CardData.ECardID.Flour:
                Nametext2.text = "����";
                BuyText2.text = "���l " + BuyGold[7] + " �~";
                break;
            case CardData.ECardID.Strawberry:
                Nametext2.text = "�C�`�S";
                BuyText2.text = "���l " + BuyGold[8] + " �~";
                break;
            case CardData.ECardID.Honey:
                Nametext2.text = "�͂��݂�";
                BuyText2.text = "���l " + BuyGold[9] + " �~";
                break;
            case CardData.ECardID.Milk:
                Nametext2.text = "�~���N";
                BuyText2.text = "���l " + BuyGold[10] + " �~";
                break;
            case CardData.ECardID.Choco:
                Nametext2.text = "�`���R";
                BuyText2.text = "���l " + BuyGold[11] + " �~";
                break;
        }
    }

    void Update()
    {

        for (int i = 0; i < 12; i++)
        {
            
            if (Input.GetKeyDown(KeyCode.Alpha1) && AAid == i && SozaiA)
            {
                PlayerData.Instance.Money -= BuyGold[i];
                Nametext.text = "";
                BuyText.text = "";
                SozaiA = false;
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && BBid == i && SozaiB)
            {
                PlayerData.Instance.Money -= BuyGold[i];
                Nametext2.text = "";
                BuyText2.text = "";
                SozaiB = false;
            }
        }

        for(int i = 0; i < 11; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3) && Number == i && Food)
            {
                PlayerData.Instance.Money -= BuyGoldF[i];
                NametextF.text = "";
                BuyTextF.text = "";
                Food = false;
            }
        }
    }

}
