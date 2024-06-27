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
    [SerializeField] List<int> BuyGold = new List<int>();//買値
    [SerializeField] List<int> BuyGoldF = new List<int>();//料理買値
    [SerializeField] List<int> SellGold = new List<int>();//売値
    [SerializeField] List<int> Percent = new List<int>();//料理確率
    List<CardData> Data = new List<CardData>();//カードの全データを取得するためのもの
    [SerializeField] int rnd;//確率計算用

    //for文に使用する専用の変数
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
        //所持金の取得
        PlayerData.Instance
                  .ReactiveProperty_Money
                  .Subscribe((money) => { MoneyText.text = money.ToString(); })
                  .AddTo(this);

        //料理カードの確率
        rnd = Random.Range(1, 100);

        if(rnd <= Percent[0])
        {
            Number = 0;
            NametextF.text = "魚の塩焼き";
            BuyTextF.text = "買値 " + BuyGoldF[0] + " 円";
        }
        else if (rnd <= Percent[1])
        {
            Number = 1;
            NametextF.text = "海鮮丼";
            BuyTextF.text = "買値 " + BuyGoldF[1] + " 円";
        }
        else if (rnd <= Percent[2])
        {
            Number = 2;
            NametextF.text = "とんかつ";
            BuyTextF.text = "買値 " + BuyGoldF[2] + " 円";
        }
        else if (rnd <= Percent[3])
        {
            Number = 3;
            NametextF.text = "カレー";
            BuyTextF.text = "買値 " + BuyGoldF[3] + " 円";
        }
        else if (rnd <= Percent[4])
        {
            Number = 4;
            NametextF.text = "野菜炒め";
            BuyTextF.text = "買値 " + BuyGoldF[4] + " 円";
        }
        else if (rnd <= Percent[5])
        {
            Number = 5;
            NametextF.text = "パンケーキ";
            BuyTextF.text = "買値 " + BuyGoldF[5] + " 円";
        }
        else if (rnd <= Percent[6])
        {
            Number = 6;
            NametextF.text = "いちごパフェ";
            BuyTextF.text = "買値 " + BuyGoldF[6] + " 円";
        }
        else if (rnd <= Percent[7])
        {
            Number = 7;
            NametextF.text = "チョコレートクレープ";
            BuyTextF.text = "買値 " + BuyGoldF[7] + " 円";
        }
        else if (rnd <= Percent[8])
        {
            Number = 8;
            NametextF.text = "果物ゼリー";
            BuyTextF.text = "買値 " + BuyGoldF[8] + " 円";
        }
        else if (rnd <= Percent[9])
        {
            Number = 9;
            NametextF.text = "ショートケーキ";
            BuyTextF.text = "買値 " + BuyGoldF[9] + " 円";
        }
        else if (rnd <= Percent[10])
        {
            Number = 10;
            NametextF.text = "チョコレートケーキ";
            BuyTextF.text = "買値 " + BuyGoldF[10] + " 円";
        }

        //Debug.Log(b);
        //Debug.Log(BuyGold[0]);


        switch (Aid)
        {
            case CardData.ECardID.Meet:
                Nametext.text = "肉";
                BuyText.text = "買値 " + BuyGold[0] + " 円";
                break;
            case CardData.ECardID.Fish:
                Nametext.text = "魚";
                BuyText.text = "買値 " + BuyGold[1] + " 円";
                break;
            case CardData.ECardID.Mash:
                Nametext.text = "キノコ";
                BuyText.text = "買値 " + BuyGold[2] + " 円";
                break;
            case CardData.ECardID.Tomato:
                Nametext.text = "トマト";
                BuyText.text = "買値 " + BuyGold[3] + " 円";
                break;
            case CardData.ECardID.Onion:
                Nametext.text = "玉ねぎ";
                BuyText.text = "買値 " + BuyGold[4] + " 円";
                break;
            case CardData.ECardID.Rice:
                Nametext.text = "お米";
                BuyText.text = "買値 " + BuyGold[5] + " 円";
                break;
            case CardData.ECardID.Zer:
                Nametext.text = "ゼラチン";
                BuyText.text = "買値 " + BuyGold[6] + " 円";
                break;
            case CardData.ECardID.Flour:
                Nametext.text = "小麦";
                BuyText.text = "買値 " + BuyGold[7] + " 円";
                break;
            case CardData.ECardID.Strawberry:
                Nametext.text = "イチゴ";
                BuyText.text = "買値 " + BuyGold[8] + " 円";
                break;
            case CardData.ECardID.Honey:
                Nametext.text = "はちみつ";
                BuyText.text = "買値 " + BuyGold[9] + " 円";
                break;
            case CardData.ECardID.Milk:
                Nametext.text = "ミルク";
                BuyText.text = "買値 " + BuyGold[10] + " 円";
                break;
            case CardData.ECardID.Choco:
                Nametext.text = "チョコ";
                BuyText.text = "買値 " + BuyGold[11] + " 円";
                break;
        }

        switch (Bid)
        {
            case CardData.ECardID.Meet:
                Nametext2.text = "肉";
                BuyText2.text = "買値 " + BuyGold[0] + " 円";
                break;
            case CardData.ECardID.Fish:
                Nametext2.text = "魚";
                BuyText2.text = "買値 " + BuyGold[1] + " 円";
                break;
            case CardData.ECardID.Mash:
                Nametext2.text = "キノコ";
                BuyText2.text = "買値 " + BuyGold[2] + " 円";
                break;
            case CardData.ECardID.Tomato:
                Nametext2.text = "トマト";
                BuyText2.text = "買値 " + BuyGold[3] + " 円";
                break;
            case CardData.ECardID.Onion:
                Nametext2.text = "玉ねぎ";
                BuyText2.text = "買値 " + BuyGold[4] + " 円";
                break;
            case CardData.ECardID.Rice:
                Nametext2.text = "お米";
                BuyText2.text = "買値 " + BuyGold[5] + " 円";
                break;
            case CardData.ECardID.Zer:
                Nametext2.text = "ゼラチン";
                BuyText2.text = "買値 " + BuyGold[6] + " 円";
                break;
            case CardData.ECardID.Flour:
                Nametext2.text = "小麦";
                BuyText2.text = "買値 " + BuyGold[7] + " 円";
                break;
            case CardData.ECardID.Strawberry:
                Nametext2.text = "イチゴ";
                BuyText2.text = "買値 " + BuyGold[8] + " 円";
                break;
            case CardData.ECardID.Honey:
                Nametext2.text = "はちみつ";
                BuyText2.text = "買値 " + BuyGold[9] + " 円";
                break;
            case CardData.ECardID.Milk:
                Nametext2.text = "ミルク";
                BuyText2.text = "買値 " + BuyGold[10] + " 円";
                break;
            case CardData.ECardID.Choco:
                Nametext2.text = "チョコ";
                BuyText2.text = "買値 " + BuyGold[11] + " 円";
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
