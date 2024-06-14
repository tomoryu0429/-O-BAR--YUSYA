using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using System;
using R3;

namespace Tani 
{
    public class PresenterWithPlayerData : MonoBehaviour
    {
        [SerializeField]
        HpBarView hpBar;
        [SerializeField]
        HorizontalCardContainer container;

        ReactiveProperty<PlayerData> playerData;
        private void Awake()
        {
            //HPに応じてHPBarのゲージを設定
            PlayerData.Instance.ReactiveProperty_HP
            .Subscribe(x => hpBar.SetHpPercent(x / 100.0f))
             .AddTo(this);

            //Hpが0になったとき「PlayerDeath」と表示
            PlayerData.Instance
                .ReactiveProperty_HP
                .Where(x => x == 0)
                .Subscribe(_ => print("PlayerDeath"))
                .AddTo(this);

                
        }
        private void Start()
        {


            container.AddCard(PlayerData.Instance.CardManager.GetCardData(CardData.ECardID.Meet));
            container.AddCard(PlayerData.Instance.CardManager.GetCardData(CardData.ECardID.Fish));
            container.AddCard(PlayerData.Instance.CardManager.GetCardData(CardData.ECardID.Mash));
            container.AddCard(PlayerData.Instance.CardManager.GetCardData(CardData.ECardID.Meet));
        }

        private void Update()
        {
            //デバッグ用
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerData.Instance.HP -= 10;
            }
        }
    }
}


