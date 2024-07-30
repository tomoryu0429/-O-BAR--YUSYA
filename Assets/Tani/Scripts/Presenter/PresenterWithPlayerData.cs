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
        PlayerData playerData;

        bool isInitialized = false;
        private async void Start()
        {
            await playerData.CS_Init.Task;
            //HPに応じてHPBarのゲージを設定
            playerData
                .HealthProperty
                .Subscribe(x => hpBar.SetHpPercent(x / 100.0f))
                .AddTo(this);

            //Hpが0になったとき「PlayerDeath」と表示
            playerData
                .HealthProperty
                .Where(x => x == 0)
                .Subscribe(_ => print("PlayerDeath"))
                .AddTo(this);

            isInitialized = true;
        }



        private void Update()
        {
            if (!isInitialized) return;
            //デバッグ用
            if (Input.GetKeyDown(KeyCode.Return))
            {
               playerData.Health -= 10;
              
            }
        }
    }
}


