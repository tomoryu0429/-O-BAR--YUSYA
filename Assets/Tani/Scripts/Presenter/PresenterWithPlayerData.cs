using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using System;
using R3;
using R3.Triggers;
using System.Linq;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;

namespace Tani 
{
    public class PresenterWithPlayerData : MonoBehaviour
    {
        [SerializeField]
        HpBarView hpBar;
        [SerializeField]
        CardContainerView hand_container;

        private void Awake()
        {
            //HPに応じてHPBarのゲージを設定
            PlayerData.Instance
                .ReactiveProperty_HP
                .Subscribe(x => hpBar.SetHpPercent(x / 100.0f))
                .AddTo(this);

            //Hpが0になったとき「PlayerDeath」と表示
            PlayerData.Instance
                .ReactiveProperty_HP
                .Where(x => x == 0)
                .Subscribe(_ => print("PlayerDeath"))
                .AddTo(this);



            PlayerData.Instance
            .CardManager
            .Hand
            .OnCardAdded += HandContainerOnCardAdded;
            PlayerData.Instance
             .CardManager
             .Hand
             .OnCardRemoved += HandContainerOnCardRemoved;

        }

        private void OnDestroy()
        {
            if (PlayerData.InstanceNullable)
            {
                PlayerData.Instance
                .CardManager
                .Hand
                .OnCardAdded -= HandContainerOnCardAdded;
                PlayerData.Instance
                 .CardManager
                 .Hand
                 .OnCardRemoved += HandContainerOnCardRemoved;
            }
            
        }
        void HandContainerOnCardAdded(int index,CardData.ECardID id)
        {
            hand_container
                .AddCard(index, PlayerData.Instance.CardManager.GetCardData(id));
        }
        void HandContainerOnCardRemoved(int index, CardData.ECardID id)
        {
            hand_container.RemoveCard(index);
        }


        async void Start()
        {
            await UniTask.Delay(1000);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Meet);
            await UniTask.Delay(1000);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Fish);
            await UniTask.Delay(1000);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Mash);
            await UniTask.Delay(1000);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Meet);
            await UniTask.Delay(1000);
            PlayerData.Instance.CardManager.Hand.Remove(1);
            await UniTask.Delay(1000);
            PlayerData.Instance.CardManager.Hand.Remove(CardData.ECardID.Mash);
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


