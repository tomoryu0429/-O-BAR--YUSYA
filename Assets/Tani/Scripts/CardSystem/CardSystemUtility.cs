using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tani;
using UnityEngine;

namespace CardSystem
{
    public static class CardSystemUtility
    {

        static Dictionary<AutoEnum.ECardID, CardData> dataList = null;

        [RuntimeInitializeOnLoadMethod]
        static public void GetData()
        {
            dataList = new();
            for (int i = 0; i < (int)AutoEnum.ECardID.Max; i++)
            {
                CardData data = Resources.Load<CardData>($"cards/{(AutoEnum.ECardID)i}");
                dataList.Add((AutoEnum.ECardID)i, data);
            }
        }


        static public CardData GetCardData(AutoEnum.ECardID id)
        {
            if(dataList == null) { throw new NullReferenceException(); }
            return dataList[id];
        }

    }

}