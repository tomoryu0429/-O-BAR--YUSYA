using System.Collections;
using System.Collections.Generic;
using Tani;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using R3;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using System.Security.Cryptography;
using TMPro;

public class BuySyounin : MonoBehaviour
{
    //[SerializeField] List<int> BuyGold = new List<int>();//���l
    [SerializeField] List<int> BuyGoldF = new List<int>();//�������l
    //[SerializeField] List<int> SellGold = new List<int>();//���l
    [SerializeField] List<int> Percent = new List<int>();//�����m��
    List<CardData> Data = new List<CardData>();//�J�[�h�̑S�f�[�^���擾���邽�߂̂���
    [SerializeField] int rnd;//�m���v�Z�p
    [SerializeField] PlayerData pd;

    //for���Ɏg�p�����p�̕ϐ�
    AutoEnum.ECardID Aid;
    AutoEnum.ECardID Bid;

    int Number;

    bool SozaiA = true;
    bool SozaiB = true;
    bool Food = true;

    [SerializeField] TextMeshProUGUI Nametext;
    [SerializeField] TextMeshProUGUI Nametext2;
    [SerializeField] TextMeshProUGUI NametextF;
    [SerializeField] TextMeshProUGUI BuyText;
    [SerializeField] TextMeshProUGUI BuyText2;
    [SerializeField] TextMeshProUGUI BuyTextF;
    [SerializeField] TextMeshProUGUI MoneyText;

    [SerializeField] List<Image> cardImage = new List<Image>();

    [SerializeField] Image S1sprite;
    [SerializeField] Image S2sprite;
   // [SerializeField] Image Fsprite;

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
        Aid = EnumSystem.GetRandom<AutoEnum.ECardID>();
        Debug.Log(Aid);
        Bid = EnumSystem.GetRandom<AutoEnum.ECardID>();
        Debug.Log(Bid);
        /*
        for(int i = 0;i < (int)CardData.ECardID.Max; i++)
        {
            Data.Add(PlayerData.Instance.CardManager.GetCardData((CardData.ECardID)i));
        }
        */
        //�������̎擾
        pd.ReactiveProperty_Money
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


        Nametext.text = pd.CardManager.GetCardData(Aid).CardName;
        BuyText.text = "���l " + pd.CardManager.GetCardData(Aid).BuyPrice + " �~";
        S1sprite.sprite = pd.CardManager.GetCardData(Aid).CardSprite;//�摜�\��

        Nametext2.text = pd.CardManager.GetCardData(Bid).CardName;
        BuyText2.text = "���l " + pd.CardManager.GetCardData(Bid).BuyPrice + " �~";
        S2sprite.sprite = pd.CardManager.GetCardData(Bid).CardSprite;//�摜�\��
        /*
        pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);//�J�[�h�ǉ�

        foreach (var i in pd.CardManager.containers[(int)CardManager.EPileType.Hand].GetAllCards())
        {
            var name = pd.CardManager.GetCardData(i).CardName;
            Debug.Log(name);
        }//�S�Ẵf�[�^�擾
        //I.sprite = pd.CardManager.GetCardData(AutoEnum.ECardID.meet_sozai_card).CardSprite;//�摜�\��
        */
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&& SozaiA)
        {
            pd.Money -= pd.CardManager.GetCardData(Aid).BuyPrice;
            Nametext.text = "";
            BuyText.text = "";
            pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(Aid);//��D�ɉ�����
            //Debug.Log();
            SozaiA = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && SozaiB)
        {
            pd.Money -= pd.CardManager.GetCardData(Bid).BuyPrice;
            Nametext2.text = "";
            BuyText2.text = "";
            pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(Bid);
            SozaiB = false;


        }

        for (int i = 0; i < 11; i++)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha3) && Number == i && Food)
                    {
                        pd.Money -= BuyGoldF[i];
                        NametextF.text = "";
                        BuyTextF.text = "";
                        Food = false;
                    }
                }
        
    }
}
