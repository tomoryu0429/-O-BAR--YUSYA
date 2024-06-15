using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tani;
using System;
using R3;
using R3.Triggers;
using System.Linq;

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
            //HP�ɉ�����HPBar�̃Q�[�W��ݒ�
            PlayerData.Instance
                .ReactiveProperty_HP
                .Subscribe(x => hpBar.SetHpPercent(x / 100.0f))
                .AddTo(this);

            //Hp��0�ɂȂ����Ƃ��uPlayerDeath�v�ƕ\��
            PlayerData.Instance
                .ReactiveProperty_HP
                .Where(x => x == 0)
                .Subscribe(_ => print("PlayerDeath"))
                .AddTo(this);

            print(PlayerData.Instance.CardManager.Hand);

            PlayerData.Instance
                .CardManager
                .Hand
                .OnCardAdded += HandContainerOnCardAdded;
        }

        private void OnDestroy()
        {
            if (PlayerData.InstanceNullable)
            {
                PlayerData.Instance
                .CardManager
                .Hand
                .OnCardAdded -= HandContainerOnCardAdded;
            }
            
        }
        void HandContainerOnCardAdded(int index,CardData.ECardID id)
        {
            hand_container
                .AddCard(index, PlayerData.Instance.CardManager.GetCardData(id));
        }

       
        private void Start()
        {


            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Meet);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Fish);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Mash);
            PlayerData.Instance.CardManager.Hand.AddCard(CardData.ECardID.Meet);
        }

        private void Update()
        {
            //�f�o�b�O�p
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerData.Instance.HP -= 10;
            }
        }
    }
}


