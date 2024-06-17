using System.Collections;
using System.Collections.Generic;
using Tani;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Syounin : MonoBehaviour
{
    [SerializeField] List<int> BuyGold = new List<int>();//買値
    [SerializeField] List<int> BuyGoldF = new List<int>();//料理買値
    [SerializeField] List<int> SellGold = new List<int>();//売値
    [SerializeField] List<int> Percent = new List<int>();//料理確率
    [SerializeField] int rnd;//確率計算用

    [SerializeField] int Money;//持っているお金（仮変数）

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

        MoneyText.text = Money + " 円";
        //料理カードの確率
        rnd = Random.Range(1, 100);
        if(rnd <= Percent[0])
        {
            NametextF.text = "魚の塩焼き";
            BuyTextF.text = "買値 " + BuyGoldF[0] + " 円";
        }
        else if (rnd <= Percent[1])
        {
            NametextF.text = "海鮮丼";
            BuyTextF.text = "買値 " + BuyGoldF[1] + " 円";
        }
        else if (rnd <= Percent[2])
        {
            NametextF.text = "とんかつ";
            BuyTextF.text = "買値 " + BuyGoldF[2] + " 円";
        }
        else if (rnd <= Percent[3])
        {
            NametextF.text = "カレー";
            BuyTextF.text = "買値 " + BuyGoldF[3] + " 円";
        }
        else if (rnd <= Percent[4])
        {
            NametextF.text = "野菜炒め";
            BuyTextF.text = "買値 " + BuyGoldF[4] + " 円";
        }
        else if (rnd <= Percent[5])
        {
            NametextF.text = "パンケーキ";
            BuyTextF.text = "買値 " + BuyGoldF[5] + " 円";
        }
        else if (rnd <= Percent[6])
        {
            NametextF.text = "いちごパフェ";
            BuyTextF.text = "買値 " + BuyGoldF[6] + " 円";
        }
        else if (rnd <= Percent[7])
        {
            NametextF.text = "チョコレートクレープ";
            BuyTextF.text = "買値 " + BuyGoldF[7] + " 円";
        }
        else if (rnd <= Percent[8])
        {
            NametextF.text = "果物ゼリー";
            BuyTextF.text = "買値 " + BuyGoldF[8] + " 円";
        }
        else if (rnd <= Percent[9])
        {
            NametextF.text = "ショートケーキ";
            BuyTextF.text = "買値 " + BuyGoldF[9] + " 円";
        }
        else if (rnd <= Percent[10])
        {
            NametextF.text = "チョコレートケーキ";
            BuyTextF.text = "買値 " + BuyGoldF[10] + " 円";
        }
        //Debug.Log(b);
        //Debug.Log(BuyGold[0]);
        switch (AAid)
        {
            case 0:
                Nametext.text = "肉";
                BuyText.text = "買値 " + BuyGold[0] + " 円";
                break;
            case 1:
                Nametext.text = "魚";
                BuyText.text = "買値 " + BuyGold[1] + " 円";
                break;
            case 2:
                Nametext.text = "キノコ";
                BuyText.text = "買値 " + BuyGold[2] + " 円";
                break;
            case 3:
                Nametext.text = "トマト";
                BuyText.text = "買値 " + BuyGold[3] + " 円";
                break;
            case 4:
                Nametext.text = "玉ねぎ";
                BuyText.text = "買値 " + BuyGold[4] + " 円";
                break;
            case 5:
                Nametext.text = "お米";
                BuyText.text = "買値 " + BuyGold[5] + " 円";
                break;
            case 6:
                Nametext.text = "ゼラチン";
                BuyText.text = "買値 " + BuyGold[6] + " 円";
                break;
            case 7:
                Nametext.text = "小麦";
                BuyText.text = "買値 " + BuyGold[7] + " 円";
                break;
            case 8:
                Nametext.text = "イチゴ";
                BuyText.text = "買値 " + BuyGold[8] + " 円";
                break;
            case 9:
                Nametext.text = "はちみつ";
                BuyText.text = "買値 " + BuyGold[9] + " 円";
                break;
            case 10:
                Nametext.text = "ミルク";
                BuyText.text = "買値 " + BuyGold[10] + " 円";
                break;
            case 11:
                Nametext.text = "チョコ";
                BuyText.text = "買値 " + BuyGold[11] + " 円";
                break;
        }
        switch (BBid)
        {
            case 0:
                Nametext2.text = "肉";
                BuyText2.text = "買値 " + BuyGold[0] + " 円";
                break;
            case 1:
                Nametext2.text = "魚";
                BuyText2.text = "買値 " + BuyGold[1] + " 円";
                break;
            case 2:
                Nametext2.text = "キノコ";
                BuyText2.text = "買値 " + BuyGold[2] + " 円";
                break;
            case 3:
                Nametext2.text = "トマト";
                BuyText2.text = "買値 " + BuyGold[3] + " 円";
                break;
            case 4:
                Nametext2.text = "玉ねぎ";
                BuyText2.text = "買値 " + BuyGold[4] + " 円";
                break;
            case 5:
                Nametext2.text = "お米";
                BuyText2.text = "買値 " + BuyGold[5] + " 円";
                break;
            case 6:
                Nametext2.text = "ゼラチン";
                BuyText2.text = "買値 " + BuyGold[6] + " 円";
                break;
            case 7:
                Nametext2.text = "小麦";
                BuyText2.text = "買値 " + BuyGold[7] + " 円";
                break;
            case 8:
                Nametext2.text = "イチゴ";
                BuyText2.text = "買値 " + BuyGold[8] + " 円";
                break;
            case 9:
                Nametext2.text = "はちみつ";
                BuyText2.text = "買値 " + BuyGold[9] + " 円";
                break;
            case 10:
                Nametext2.text = "ミルク";
                BuyText2.text = "買値 " + BuyGold[10] + " 円";
                break;
            case 11:
                Nametext2.text = "チョコ";
                BuyText2.text = "買値 " + BuyGold[11] + " 円";
                break;
        }
    }

    void Update()
    {
        
    }
    
}
