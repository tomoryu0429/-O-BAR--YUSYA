using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using R3;
using Tani;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField]
    Text text;

    private void Start()
    {
        PlayerData.Instance
            .ReactiveProperty_Money
            .Subscribe((money) => { text.text = money.ToString(); })
            .AddTo(this);

        PlayerData.Instance
            .CardManager
            .Hand
            .OnCardAdded += (int index, CardData.ECardID id) =>
            {
                print($"インデックス : {index}");
                print($"id : {id.ToString()}");
            };
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var data =  PlayerData.Instance.CardManager.GetCardData(CardData.ECardID.Meet);
            print(data.CardName);
            print(data.BuyPrice);

        }
    }


}
