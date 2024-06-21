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
        //[SerializeField]
        //CardContainerView draw_container;
        //[SerializeField]
        //CardContainerView discard_container;

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

            //PlayerData.Instance
            //.CardManager
            //.Draw
            //.OnCardAdded += DrawContainerOnCardAdded;
            //PlayerData.Instance
            // .CardManager
            // .Draw
            // .OnCardRemoved += DrawContainerOnCardRemoved;

            //PlayerData.Instance
            //    .CardManager
            //    .Discard
            //    .OnCardAdded += DiscardContainerOnCardAdded;
            //PlayerData.Instance
            // .CardManager
            // .Discard
            // .OnCardRemoved += DiscardContainerOnCardRemoved;

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
                 .OnCardRemoved -= HandContainerOnCardRemoved;

                //PlayerData.Instance
                //   .CardManager
                //.Draw
                //.OnCardAdded -= DrawContainerOnCardAdded;
                //PlayerData.Instance
                // .CardManager
                // .Draw
                // .OnCardRemoved -= DrawContainerOnCardRemoved;

                //PlayerData.Instance
                //    .CardManager
                //    .Discard
                //    .OnCardAdded -= DiscardContainerOnCardAdded;
                //PlayerData.Instance
                // .CardManager
                // .Discard
                // .OnCardRemoved -= DiscardContainerOnCardRemoved;
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

        //void DrawContainerOnCardAdded(int index, CardData.ECardID id)
        //{
        //    draw_container
        //       .AddCard(index, PlayerData.Instance.CardManager.GetCardData(id));
        //}
        //void DrawContainerOnCardRemoved(int index, CardData.ECardID id)
        //{
        //    draw_container.RemoveCard(index);
        //}
        //void DiscardContainerOnCardAdded(int index, CardData.ECardID id)
        //{
        //    discard_container
        //       .AddCard(index, PlayerData.Instance.CardManager.GetCardData(id));
        //}
        //void DiscardContainerOnCardRemoved(int index, CardData.ECardID id)
        //{
        //    discard_container.RemoveCard(index);
        //}


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

            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Meet);
            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Fish);
            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Mash);
            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Rice);
            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Rice);
            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Onion);
            PlayerData.Instance.CardManager.Draw.AddCard(CardData.ECardID.Onion);

            //Tani.TurnController.ChangeTurn(TurnController.ETurn.CardTurn);



        }
        int count = 0;
        private void Update()
        {
            //デバッグ用
            if (Input.GetKeyDown(KeyCode.Return))
            {
                count++;
                PlayerData.Instance.HP -= 10;
                Tani.TurnController.ChangeTurn((Tani.TurnController.ETurn)(count % (int)Tani.TurnController.ETurn.TurnMax));
            }
        }
    }
}


