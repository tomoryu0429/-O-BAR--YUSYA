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
    [SerializeField] BuySyounin buysyounin;

    [SerializeField] List<TextMeshProUGUI> handName = new List<TextMeshProUGUI>();
    [SerializeField] List<TextMeshProUGUI> sellprice = new List<TextMeshProUGUI>();
    [SerializeField] List<int> Sprice = new List<int>();
    [SerializeField] bool sell = true;

    int i = 0;

    SyouninManager sm;

    //prehab
    [SerializeField] GameObject Sellpb;

    [SerializeField] Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        sm = FindAnyObjectByType<SyouninManager>();

        //pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.meet_sozai_card);
        //pd.CardManager.containers[(int)CardManager.EPileType.Hand].AddCard(AutoEnum.ECardID.mash_sozai_card);

        //所持金の取得
        PlayerData.Instance.Status.Money.Observable.Subscribe(money =>
        {
            sm.moneyText.text = money.Value.ToString();
        }).AddTo(this);
        /*
        //購入した際の更新
        for(int i = 0; i < buysyounin.canBuy.Count; i++)
        {

        }
        */

        foreach (var hand in PlayerData.Instance.CardManager.GetSortedAllCardList())
        {

            var name = CardSystem.CardSystemUtility.GetCardData(hand).CardName;
            var price = CardSystem.CardSystemUtility.GetCardData(hand).SellOPrice;
            GameObject Sellget = Instantiate(Sellpb, trans);
            Sellget.transform.Translate(-20, -30 * i + 110, 0);
            SellPrehab SP = Sellget.GetComponent<SellPrehab>();
            SP.handID = CardSystem.CardSystemUtility.GetCardData(hand).CardID;
            SP.handname.text = name;
            SP.sellprice.text = "売値　" + price + "　円";
            SP.SellButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (sell)
                    {
                        PlayerData.Instance.Status.Money.Value += price;
                        Destroy(Sellget);
                        PlayerData.Instance.CardManager.DrawpileCardContainer.Remove(SP.handID);
                        sell = false;
                    }
                })
            .AddTo(this);
            i++;
        }

    }

}
