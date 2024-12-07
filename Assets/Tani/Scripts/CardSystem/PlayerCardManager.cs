using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alchemy.Inspector;
using System.Linq;
using Cysharp.Threading.Tasks;
using R3;
using System;

namespace Tani
{
    /// <summary>
    /// �v���C���[�p�̃J�[�h�R���e�C�i�[���Ǘ�����Wrapper�N���X
    /// </summary>
    
    
    public class PlayerCardManager
    {

        public CardContainer HandCardContainer { get; }
        public CardContainer DiscardCardContainer { get; }
        public CardContainer DrawpileCardContainer { get; }

        private PlayerStatus Status { get; }

        private float _cardEffectMultiply = 1f;
        public PlayerCardManager(PlayerStatus playerStatus)
        {

            HandCardContainer = new CardContainer();
            DiscardCardContainer = new CardContainer();
            DrawpileCardContainer = new CardContainer();
            Status = playerStatus;

        }


        public  void UseCard(CardContainer container,int index)
        {
            AutoEnum.ECardID item = container[index];
            container.MoveCardToAnotherContainer(index, DiscardCardContainer);
            //�J�[�h�̌��ʂ𔭓�����
            Debug.Log($"{CardSystem.Utility.GetCardData(item).CardName}���g�p");
            ApplyCardEffect(item);
            Status.RemainingUseCount.Value--;
            

        }

        public void MoveHandCardContainerCardToDiscardContainer()
        {
            DiscardCardContainer.Add(HandCardContainer);
            HandCardContainer.Clear();
        }

        //�R�D����ꖇ�����A��D�Ɉړ�
        public void DrawCard()
        {

            IndexIdPair drawedData = DrawpileCardContainer.GetRandom();

            if (drawedData != null)//DrawPile�ɃJ�[�h�����݂��Ă���
            {
                DrawpileCardContainer.MoveCardToAnotherContainer(drawedData.index, HandCardContainer);
            }
            else//Drawpile�ɃJ�[�h�����݂��Ȃ�����DiscardPile���玝���Ă��āA����
            {
                DrawpileCardContainer.Add(DiscardCardContainer);
                DiscardCardContainer.Clear();
                if(DrawpileCardContainer.Count == 0) { throw new Exception("�J�[�h�����݂��܂���"); }
                DrawCard();

            }
        }

        public List<AutoEnum.ECardID> GetSortedAllCardList()
        {
            var all = HandCardContainer
                .Concat( DiscardCardContainer)
                .Concat(DrawpileCardContainer);

            List<AutoEnum.ECardID> sortedList = new List<AutoEnum.ECardID>();
            for(int i = 0;i < (int)AutoEnum.ECardID.Max; i++)
            {
                sortedList.AddRange(all.Where(id => id == (AutoEnum.ECardID)i));
            }
            return sortedList;
        }



        private void ApplyCardEffect(AutoEnum.ECardID id)
        {
            var data = CardSystem.Utility.GetCardData(id);
            foreach(var card in data.Effects)
            {
                card?.ApplyEffect(Status);
                Debug.Log($"�J�[�h���� : {card?.EffectLabel},�l : {card?.ChangeValue}");
            }
        }
    }
}


