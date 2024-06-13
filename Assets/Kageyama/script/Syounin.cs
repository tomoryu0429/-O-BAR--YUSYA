using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Syounin : MonoBehaviour
{
    [SerializeField] List<int> BuyGold = new List<int>();//買値
    [SerializeField] List<int> SellGold = new List<int>();//売値

    [SerializeField] int Money;//持っているお金（仮変数）

    string aa;
    int aaa;
    [SerializeField] Text Nametext;
    [SerializeField] Text BuyText;
    //[SerializeField] Text SellText;
    //[SerializeField] Image image;

    public enum FbName
    {
        Meat,
        Fish,
        Mushroom,
        Tomato,
        Onion,
        Rice,
        Gelatin,
        Wheat,
        Strawberry,
        Honey,
        Milk,
        Chocolate,
    }

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
        FbName a = EnumSystem.GetRandom<FbName>();
        Debug.Log(a);
        //aa = a.ToString();
        aaa = (int)a;
        FbName b = EnumSystem.GetRandom<FbName>();
        //Debug.Log(b);
        //Debug.Log(BuyGold[0]);
        switch (aaa)
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
    }

    void Update()
    {
        
    }
    
}
