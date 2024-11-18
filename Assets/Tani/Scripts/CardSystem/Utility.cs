using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tani;
using UnityEngine;
using System.Linq;

namespace CardSystem
{
    public static class Utility
    {

        static private Dictionary<AutoEnum.ECardID, CardData> dataList = null;
        static private List<int> primeNumberList = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void GetCardDatasFromResources() 
        {
            dataList = new();
            for (int i = 0; i < (int)AutoEnum.ECardID.Max; i++)
            {
                CardData data = Resources.Load<CardData>($"cards/{(AutoEnum.ECardID)i}");
                dataList.Add((AutoEnum.ECardID)i, data);
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void InitializePrimeNumberList()
        {
            primeNumberList = GetPrimeNumbers((int)AutoEnum.ECardID.Max);
        }

        //�����V�X�e��
        //�e�J�[�h�ɂ�(int)cardId�Ԗڂ̑f��������U���Ă���
        //�f�ރJ�[�h�̑f���̐ς������J�[�h�̑f���̐ςɓ������Ƃ��A���̗������쐬�ł���

        /// <summary>
        /// �^����ꂽID�̃J�[�h���쐬����̂ɕK�v�ȑf�ރJ�[�h�̑f���̐ς�Ԃ��܂��B�쐬�\�łȂ��ꍇ0���Ԃ�܂�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public int GetIngredientsProduct(AutoEnum.ECardID id)
        {
            CardData cardData = dataList[id];
            if(cardData == null) { return 0; }

            if ( cardData.Cookable == false) { return 0; }

            int product = 1;
            foreach(AutoEnum.ECardID ingredientId in cardData.Ingredients)
            {
                product *= primeNumberList[(int)id];
            }
            return product;
        }

        

        static public CardData GetCardData(AutoEnum.ECardID id)
        {
            if(dataList == null) { throw new NullReferenceException(); }
            return dataList[id];
        }



        static public AutoEnum.ECardID GetCraftableCardId(int product)
        {
            foreach(var pair in dataList)
            {
                if(pair.Value == null) { continue; }
                if(GetIngredientsProduct(pair.Key) == product)
                {
                    return pair.Key;
                }
            }
            return AutoEnum.ECardID.Invalid;
        }

        static public int GetCardIdPrimeNumber(AutoEnum.ECardID id)
        {
            return primeNumberList[(int)id];
        }

        static List<int> GetPrimeNumbers(int primeNumberAmount)
        {
            List<int> primeNumbers = new(primeNumberAmount);

            primeNumbers.Add(2);

            int currentIndex = 3;
            while (true)
            {
                if (primeNumbers.Count == primeNumberAmount) { break; }

                for (int i = 0; i < primeNumbers.Count; i++)
                {
                    if (primeNumbers[i] > currentIndex / 2.0f)
                    {
                        primeNumbers.Add(currentIndex);
                        break;
                    }
                    if (currentIndex % primeNumbers[i] == 0)
                    {
                        break;
                    }
                }

                currentIndex++;
            }

            return primeNumbers;
        }
    }


}