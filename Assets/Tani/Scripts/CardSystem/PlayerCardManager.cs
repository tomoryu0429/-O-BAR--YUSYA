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

        public PlayerCardManager()
        {

            HandCardContainer = new CardContainer();
            DiscardCardContainer = new CardContainer();
            DrawpileCardContainer = new CardContainer();


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

        public void ResetRemainingUseCount() => RemainingUseCount = 1;

    }
}


