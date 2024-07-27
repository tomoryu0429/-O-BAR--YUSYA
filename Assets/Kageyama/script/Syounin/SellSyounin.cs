using System.Collections;
using System.Collections.Generic;
using Tani;
using TMPro;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class SellSyounin : MonoBehaviour
{
    [SerializeField] PlayerData pd;

    [SerializeField] List<TextMeshProUGUI> handName = new List<TextMeshProUGUI>();
    [SerializeField] List<TextMeshProUGUI> sellprice = new List<TextMeshProUGUI>();
    [SerializeField] List<int> Sprice = new List<int>();
    [SerializeField] bool sell = true;

    [SerializeField] TextMeshProUGUI MoneyText;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);
        //pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.mash_sozai_card);

        //èäéùã‡ÇÃéÊìæ
        pd.ReactiveProperty_Money
                  .Subscribe((money) => { MoneyText.text = money.ToString(); })
                  .AddTo(this);

        foreach (var hand in pd.CardManager.containers[(int)CardManager.EPileType.Hand].GetAllCards())
        {
            var name = pd.CardManager.GetCardData(hand).CardName;
            var price = pd.CardManager.GetCardData(hand).SellOPrice;
            Debug.Log(name);
            handName[i].text = name;
            sellprice[i].text = "îÑílÅ@" + price + "Å@â~";
            Sprice[i] = price;
            i++;
            Debug.Log(i);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && sell)
        {
            pd.Money += Sprice[0];
            sell = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && sell)
        {
            pd.Money += Sprice[1];
            sell = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && sell)
        {
            pd.Money += Sprice[2];
            sell = false;
        }
    }
}
