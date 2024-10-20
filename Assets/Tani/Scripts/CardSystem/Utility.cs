using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tani;
using UnityEngine;

namespace CardSystem
{
    public static class Utility
    {

        static private Dictionary<AutoEnum.ECardID, CardData> dataList = null;
        static private List<uint> PrimeNumberList = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void GetData()
        {
            dataList = new();
            for (int i = 0; i < (int)AutoEnum.ECardID.Max; i++)
            {
                CardData data = Resources.Load<CardData>($"cards/{(AutoEnum.ECardID)i}");
                dataList.Add((AutoEnum.ECardID)i, data);
            }
        }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void GetPrimeNumbers()
        {
            TextAsset primeNumberTextAsset = Resources.Load<TextAsset>("PrimeNumbers");
            string[] split = primeNumberTextAsset.text.Split(',');
            for(int i = 0; i < split.Length; i++)
            {
                if(uint.TryParse(split[i],out uint num))
                {
                    PrimeNumberList.Add(num);
                    Debug.Log($"Test,Added Prime Num : {num}");
                }
            }
        }

        static public CardData GetCardData(AutoEnum.ECardID id)
        {
            if(dataList == null) { throw new NullReferenceException(); }
            return dataList[id];
        }

        static public uint GetPrimeNumber(uint index)
        {
            if(index >= PrimeNumberList.Count) { throw new System.ArgumentOutOfRangeException(); }
            return PrimeNumberList[(int)index];
        }

        static public AutoEnum.ECardID GetCraftableCardId(uint product)
        {
            foreach(var pair in dataList)
            {
                if(pair.Value == null) { continue; }
                if(pair.Value.GetIngredientsProduct() == product)
                {
                    return pair.Key;
                }
            }
            return AutoEnum.ECardID.Invalid;
        }

    }


}