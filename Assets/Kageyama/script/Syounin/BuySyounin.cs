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
    //[SerializeField] List<int> BuyGold = new List<int>();//買値
    [SerializeField] List<int> BuyGoldF = new List<int>();//料理買値
    //[SerializeField] List<int> SellGold = new List<int>();//売値
    [SerializeField] List<int> Percent = new List<int>();//料理確率
    List<CardData> Data = new List<CardData>();//カードの全データを取得するためのもの
    [SerializeField] int rnd;//確率計算用
    [SerializeField] PlayerData pd;

    //for文に使用する専用の変数
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
        //所持金の取得
        pd.ReactiveProperty_Money
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


        Nametext.text = pd.CardManager.GetCardData(Aid).CardName;
        BuyText.text = "買値 " + pd.CardManager.GetCardData(Aid).BuyPrice + " 円";
        S1sprite.sprite = pd.CardManager.GetCardData(Aid).CardSprite;//画像表示

        Nametext2.text = pd.CardManager.GetCardData(Bid).CardName;
        BuyText2.text = "買値 " + pd.CardManager.GetCardData(Bid).BuyPrice + " 円";
        S2sprite.sprite = pd.CardManager.GetCardData(Bid).CardSprite;//画像表示
        /*
        pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);//カード追加

        foreach (var i in pd.CardManager.containers[(int)CardManager.EPileType.Hand].GetAllCards())
        {
            var name = pd.CardManager.GetCardData(i).CardName;
            Debug.Log(name);
        }//全てのデータ取得
        //I.sprite = pd.CardManager.GetCardData(AutoEnum.ECardID.meet_sozai_card).CardSprite;//画像表示
        */
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&& SozaiA)
        {
            pd.Money -= pd.CardManager.GetCardData(Aid).BuyPrice;
            Nametext.text = "";
            BuyText.text = "";
            pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(Aid);//手札に加える
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
