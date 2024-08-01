using System.Collections;
using System.Collections.Generic;
using Tani;
using TMPro;
using R3;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Security.Cryptography;
using AutoEnum;
using UnityEngine.XR;
using Unity.VisualScripting;

public class SellSyounin : MonoBehaviour
{
    [SerializeField] PlayerData pd;
    [SerializeField] CardContainer cc;

 //   [SerializeField] List<TextMeshProUGUI> handName = new List<TextMeshProUGUI>();
  //  [SerializeField] List<TextMeshProUGUI> sellprice = new List<TextMeshProUGUI>();
    [SerializeField] List<int> Sprice = new List<int>();
    [SerializeField] bool sell = true;

    [SerializeField] TextMeshProUGUI MoneyText;

    int i = 0;
    [SerializeField] ECardID HandID;

    //prehab
    [SerializeField] GameObject Sellpb;

    [SerializeField]Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        //pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);
        //pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.mash_sozai_card);

        //ŠŽ‹à‚ÌŽæ“¾
        pd.ReactiveProperty_Money
                  .Subscribe((money) => { MoneyText.text = money.ToString(); })
        .AddTo(this);


        foreach (var hand in pd.CardManager.containers[(int)CardManager.EPileType.Hand].GetAllCards())
        {

            var name = pd.CardManager.GetCardData(hand).CardName;
            var price = pd.CardManager.GetCardData(hand).SellOPrice;
            HandID = pd.CardManager.GetCardData(hand).CardID;
            GameObject Sellget = Instantiate(Sellpb, trans);
            Sellget.transform.Translate(0, -30 * i, 0);
            SellPrehab SP = Sellget.GetComponent<SellPrehab>();
            SP.handname.text = name;
            SP.sellprice.text = "”„’l@" + price + "@‰~";
            SP.SellButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (sell)
                    {
                        pd.Money += price;
                        Destroy(Sellget);
                        pd.CardManager.containers[(int)CardManager.EPileType.Hand].Remove(HandID);
                        sell = false;
                    }
                })
            .AddTo(this);
            i++;
        }

    }
        // Update is called once per frame
        void Update()
        {

        }

    }
