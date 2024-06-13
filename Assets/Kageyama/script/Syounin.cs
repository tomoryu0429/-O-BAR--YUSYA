using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Syounin : MonoBehaviour
{
    [SerializeField] List<int> BuyGold = new List<int>();//���l
    [SerializeField] List<int> SellGold = new List<int>();//���l

    [SerializeField] int Money;//�����Ă��邨���i���ϐ��j

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
    }

    void Update()
    {
        
    }
    
}
