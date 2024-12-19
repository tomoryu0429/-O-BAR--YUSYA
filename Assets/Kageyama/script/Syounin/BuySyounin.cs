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
    //[SerializeField] List<int> buyGold = new List<int>();//買値
    [SerializeField] List<int> BuyGoldF = new List<int>();//料理買値
    [SerializeField] List<int> Percent = new List<int>();//料理確率
    //List<CardData> Data = new List<CardData>();//カードの全データを取得するためのもの
    [SerializeField] int rnd;//確率計算用
    //[SerializeField] PlayerData pd;

    //for文に使用する専用の変数
    AutoEnum.ECardID buy1_id;
    AutoEnum.ECardID buy2_id;

    int Number;

    //最初はすべてTrueにしておく
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

        //所持金の取得
        PlayerData.Instance.Status.Money.Observable.Subscribe(money =>
        {
            sm.moneyText.text = money.Value.ToString();
        }).AddTo(this);
        
        //テスト用、変更点
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
                    //PlayerData.Instance.CardManager.HandCardContainer.Add(buy2_id);//手札に加える
                    canBuy[2] = false;
                });
        }

    }
        

     void PurchaseCard(AutoEnum.ECardID buyid, int id)
    {
        PlayerData.Instance.Status.Money.Value -= CardSystem.CardSystemUtility.GetCardData(buyid).BuyPrice;
        nameText[id].text = "";
        buyText[id].text = "";
        PlayerData.Instance.CardManager.HandCardContainer.Add(buyid);//手札に加える
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

        //料理カードの確率
        rnd = Random.Range(1, 100);

        if (rnd <= Percent[0])
        {
            Number = 0;
            nameText[2].text = "魚の塩焼き";//データが出来たら変更する
            buyText[2].text = "買値 " + BuyGoldF[0] + " 円";
        }

        for (int i = 1; i < 11; i++)
        {
            if (rnd > Percent[i - 1] && rnd <= Percent[i])
            {
                Number = i;
                nameText[2].text = "魚の塩焼き" + i;//データが出来たら変更する
                buyText[2].text = "買値 " + BuyGoldF[i] + " 円";
            }
        }
    }

    void ViewCardData()
    {
         nameText[0].text = CardSystem.CardSystemUtility.GetCardData(buy1_id).CardName;
         buyText[0].text = "買値 " + CardSystem.CardSystemUtility.GetCardData(buy1_id).BuyPrice + " 円";
         S1sprite.sprite = CardSystem.CardSystemUtility.GetCardData(buy1_id).CardSprite;//画像表示

         nameText[1].text = CardSystem.CardSystemUtility.GetCardData(buy2_id).CardName;
         buyText[1].text = "買値 " + CardSystem.CardSystemUtility.GetCardData(buy2_id).BuyPrice + " 円";
         S2sprite.sprite = CardSystem.CardSystemUtility.GetCardData(buy2_id).CardSprite;//画像表示

        //PlayerData.Instance.CardManager.GetSortedAllCardList();//データ取得
        //PlayerData.Instance.CardManager.DrawpileCardContainer.Remove(); 消せる

        foreach(var i in PlayerData.Instance.CardManager.GetSortedAllCardList())
        {
            var name = CardSystem.CardSystemUtility.GetCardData(i).CardName;
            Debug.Log(name);
        }

        /*
        pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);//カード追加

        //I.sprite = pd.CardManager.GetCardData(AutoEnum.ECardID.meet_sozai_card).CardSprite;//画像表示
        */
    }
}

