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
    public class PresenterWithPlayerData : UIGroup
    {
        [SerializeField]
        BarView hpBar;
    
        PlayerData playerData;

        public override void Initialize()
        {
            playerData = PlayerData.Instance;

            //HPに応じてHPBarのゲージを設定
            playerData
                .Status
                .Health
                .Observable
                .Subscribe(x => hpBar.SetBarPercent(x.Value / (float)x.Max))
                .AddTo(this);

            //Hpが0になったとき「PlayerDeath」と表示
            playerData
                .Status
                .PlayerDieAsObservable
                .Subscribe(_ => print("PlayerDeath"))
                .AddTo(this);
        }
        private void Update()
        {
            //デバッグ用
            if (Input.GetKeyDown(KeyCode.Return))
            {
               playerData.Status.Health.Value -= 10;
              
            }
        }
    }
}


