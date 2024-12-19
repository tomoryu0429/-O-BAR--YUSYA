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
using R3.Triggers;
using old;

public class BuySyounin : MonoBehaviour
{
    //[SerializeField] List<int> buyGold = new List<int>();//���l
    [SerializeField] List<int> BuyGoldF = new List<int>();//�������l
    [SerializeField] List<int> Percent = new List<int>();//�����m��
    //List<CardData> Data = new List<CardData>();//�J�[�h�̑S�f�[�^���擾���邽�߂̂���
    [SerializeField] int rnd;//�m���v�Z�p
    //[SerializeField] PlayerData pd;

    //for���Ɏg�p�����p�̕ϐ�
    AutoEnum.ECardID buy1_id;
    AutoEnum.ECardID buy2_id;

    int Number;

    //�ŏ��͂��ׂ�True�ɂ��Ă���
    public List<bool> canBuy = new List<bool>();

    [SerializeField] List<TextMeshProUGUI> nameText = new List<TextMeshProUGUI>();
    [SerializeField] List<TextMeshProUGUI> buyText = new List<TextMeshProUGUI>();

    [SerializeField] List<Button> buybutton = new List<Button>();
   // [SerializeField] List<Image> cardImage = new List<Image>();

    [SerializeField] Image S1sprite;
    [SerializeField] Image S2sprite;
    // [SerializeField] Image Fsprite;

    //[SerializeField] Text SellText;
    //[SerializeField] Image image;

    SyouninManager sm;

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
        sm = FindAnyObjectByType<SyouninManager>();

        GetBuyID();

        //�������̎擾
        PlayerData.Instance.Status.Money.Observable.Subscribe(money =>
        {
            sm.moneyText.text = money.Value.ToString();
        }).AddTo(this);
        
        //�e�X�g�p�A�ύX�_
        PlayerData.Instance.Status.Money.Value += 300;

        ViewCardData();

        buybutton[0].OnClickAsObservable()
                    .Where(_ => canBuy[0] && PlayerData.Instance.Status.Money.Value >= CardSystem.CardSystemUtility.GetCardData(buy1_id).BuyPrice)
                    .Subscribe(_ => PurchaseCard(buy1_id, 0));

        buybutton[1].OnClickAsObservable()
                    .Where(_ => canBuy[1] && PlayerData.Instance.Status.Money.Value >= CardSystem.CardSystemUtility.GetCardData(buy2_id).BuyPrice)
                    .Subscribe(_ => PurchaseCard(buy2_id, 1));

        for (int i = 0; i < 11; i++)
        {
            int index = i;
            buybutton[2].OnClickAsObservable()
                .Where(_ => Number == index && canBuy[2] && PlayerData.Instance.Status.Money.Value >= BuyGoldF[index])
                .Subscribe(_ =>
                {
                    PlayerData.Instance.Status.Money.Value -= BuyGoldF[index];
                    nameText[2].text = "";
                    buyText[2].text = "";
                    Debug.Log(index);
                    //PlayerData.Instance.CardManager.HandCardContainer.Add(buy2_id);//��D�ɉ�����
                    canBuy[2] = false;
                });
        }

    }
        

     void PurchaseCard(AutoEnum.ECardID buyid, int id)
    {
        PlayerData.Instance.Status.Money.Value -= CardSystem.CardSystemUtility.GetCardData(buyid).BuyPrice;
        nameText[id].text = "";
        buyText[id].text = "";
        PlayerData.Instance.CardManager.HandCardContainer.Add(buyid);//��D�ɉ�����
        Debug.Log(id);
        canBuy[id] = false;
    }


     void GetBuyID()
    {
        buy1_id = EnumSystem.GetRandom<AutoEnum.ECardID>();
        Debug.Log(buy1_id);
        buy2_id = EnumSystem.GetRandom<AutoEnum.ECardID>();
        Debug.Log(buy2_id);
        while (buy1_id == buy2_id)
        {
            buy2_id = EnumSystem.GetRandom<AutoEnum.ECardID>();
        }

        //�����J�[�h�̊m��
        rnd = Random.Range(1, 100);

        if (rnd <= Percent[0])
        {
            Number = 0;
            nameText[2].text = "���̉��Ă�";//�f�[�^���o������ύX����
            buyText[2].text = "���l " + BuyGoldF[0] + " �~";
        }

        for (int i = 1; i < 11; i++)
        {
            if (rnd > Percent[i - 1] && rnd <= Percent[i])
            {
                Number = i;
                nameText[2].text = "���̉��Ă�" + i;//�f�[�^���o������ύX����
                buyText[2].text = "���l " + BuyGoldF[i] + " �~";
            }
        }
    }

    void ViewCardData()
    {
         nameText[0].text = CardSystem.CardSystemUtility.GetCardData(buy1_id).CardName;
         buyText[0].text = "���l " + CardSystem.CardSystemUtility.GetCardData(buy1_id).BuyPrice + " �~";
         S1sprite.sprite = CardSystem.CardSystemUtility.GetCardData(buy1_id).CardSprite;//�摜�\��

         nameText[1].text = CardSystem.CardSystemUtility.GetCardData(buy2_id).CardName;
         buyText[1].text = "���l " + CardSystem.CardSystemUtility.GetCardData(buy2_id).BuyPrice + " �~";
         S2sprite.sprite = CardSystem.CardSystemUtility.GetCardData(buy2_id).CardSprite;//�摜�\��

        //PlayerData.Instance.CardManager.GetSortedAllCardList();//�f�[�^�擾
        //PlayerData.Instance.CardManager.DrawpileCardContainer.Remove(); ������

        foreach(var i in PlayerData.Instance.CardManager.GetSortedAllCardList())
        {
            var name = CardSystem.CardSystemUtility.GetCardData(i).CardName;
            Debug.Log(name);
        }

        /*
        pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);//�J�[�h�ǉ�

        //I.sprite = pd.CardManager.GetCardData(AutoEnum.ECardID.meet_sozai_card).CardSprite;//�摜�\��
        */
    }
}

