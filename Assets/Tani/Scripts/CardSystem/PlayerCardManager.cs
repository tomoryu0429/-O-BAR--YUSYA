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

        public int RemainingUseCount { get;  set; } = 1;
        private PlayerStatus Status { get; }

        private float _cardEffectMultiply = 1f;
        public PlayerCardManager(PlayerStatus playerStatus)
        {

            HandCardContainer = new CardContainer();
            DiscardCardContainer = new CardContainer();
            DrawpileCardContainer = new CardContainer();
            Status = playerStatus;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="index"></param>
        /// <returns>����ȏ�J�[�h���g�p�ł��Ȃ����true</returns>
        public  bool UseCard(CardContainer container,int index)
        {
            AutoEnum.ECardID item = container[index];
            container.MoveCardToAnotherContainer(index, DiscardCardContainer);
            //�J�[�h�̌��ʂ𔭓�����

            RemainingUseCount--;
            if(RemainingUseCount > 0)
            { 
                return false;
            }
            else
            {
                DiscardCardContainer.Add(container);
                container.Clear();
                return true;
            }
            

        }

        //�R�D����ꖇ�����A��D�Ɉړ�
        public void DrawCard()
        {

            (AutoEnum.ECardID item, int index)? drawedData = DrawpileCardContainer.GetRandom();

            if (drawedData.HasValue)//DrawPile�ɃJ�[�h�����݂��Ă���
            {
                DrawpileCardContainer.MoveCardToAnotherContainer(drawedData.Value.index, HandCardContainer);
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

        public void ResetUsage() 
        {
            RemainingUseCount = 1;
            _cardEffectMultiply = 1;
        }


        private void ApplyCardEffect(AutoEnum.ECardID id)
        {
            CardData data = CardSystem.Utility.GetCardData(id);
            foreach(CardData.CardEffectType effectType in data.EffectList)
            {
                switch (effectType)
                {
                    case CardData.CardEffectType.MotivationIncreaseSmall:
                        Status.Motivation.Value += (int)(CardSystem.Utility.MasterData.MotivationIncreaseSmall * _cardEffectMultiply);
                        break;
                    case CardData.CardEffectType.MotivationIncreaseMiddle:
                        Status.Motivation.Value += (int)(CardSystem.Utility.MasterData.MotivationIncreaseMiddle * _cardEffectMultiply);
                        break;
                    case CardData.CardEffectType.MotivationIncreaseLarge:
                        Status.Motivation.Value += (int)(CardSystem.Utility.MasterData.MotivationIncreaseLarge * _cardEffectMultiply);
                        break;
                    case CardData.CardEffectType.GuardIncreaseSmall:
                        Status.Guard.Value += (int)(CardSystem.Utility.MasterData.GuardIncreaseSmall * _cardEffectMultiply);
                        break;
                    case CardData.CardEffectType.GuardIncreaseMiddle:
                        Status.Guard.Value += (int)(CardSystem.Utility.MasterData.GuardIncreaseMiddle * _cardEffectMultiply);
                        break;
                    case CardData.CardEffectType.GuardIncreaseLarge:
                        Status.Guard.Value += (int)(CardSystem.Utility.MasterData.GuardIncreaseLarge * _cardEffectMultiply);
                        break;
                    case CardData.CardEffectType.CardEffectIncreaseSmall:
                        _cardEffectMultiply *= CardSystem.Utility.MasterData.CardEffectIncreaseSmall;
                        break;
                    case CardData.CardEffectType.CardEffectIncreaseMiddle:
                        _cardEffectMultiply *= CardSystem.Utility.MasterData.CardEffectIncreaseMiddle;
                        break;
                    case CardData.CardEffectType.CardEffectIncreaseLarge:
                        _cardEffectMultiply *= CardSystem.Utility.MasterData.CardEffectIncreaseLarge;
                        break;
                    case CardData.CardEffectType.AddCardUsageCount:
                        RemainingUseCount++;
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
            }
        }
    }
}


