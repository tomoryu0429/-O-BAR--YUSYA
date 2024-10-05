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
        static public CardMasterData MasterData { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void GetData()
        {
            dataList = new();
            for (int i = 0; i < (int)AutoEnum.ECardID.Max; i++)
            {
                CardData data = Resources.Load<CardData>($"cards/{(AutoEnum.ECardID)i}");
                dataList.Add((AutoEnum.ECardID)i, data);
            }

            MasterData = Resources.Load<CardMasterData>("cards/CardMasterData");
        }


        static public CardData GetCardData(AutoEnum.ECardID id)
        {
            if(dataList == null) { throw new NullReferenceException(); }
            return dataList[id];
        }

    }


}