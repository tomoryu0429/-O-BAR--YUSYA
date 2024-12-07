using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Tani;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;




public class PlayerData 
{

    private PlayerData() { }

    private static PlayerData instance = null;
    public static PlayerData Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = new PlayerData();
            instance.Initialize();
            return instance;
        }
    }

    public PlayerCardManager CardManager { get; private set; } = null;
    public PlayerStatus Status { get; private set; } = null;

    private void Initialize()
    {
        Status = new PlayerStatus();
        CardManager = new PlayerCardManager(Status);
       

        for (int i = 0; i < 8; i++)
        {
            var id = (AutoEnum.ECardID)Mathf.FloorToInt(Random.Range(0, (int)AutoEnum.ECardID.Max));
            Debug.Log($"ƒJ[ƒh’Ç‰Á : {id.ToString()}");
            CardManager.DrawpileCardContainer
                .Add(id);

        }
    }

}


