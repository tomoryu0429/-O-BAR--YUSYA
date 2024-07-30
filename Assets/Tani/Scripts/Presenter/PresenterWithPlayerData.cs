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
            //HP�ɉ�����HPBar�̃Q�[�W��ݒ�
            playerData
                .HealthProperty
                .Subscribe(x => hpBar.SetHpPercent(x / 100.0f))
                .AddTo(this);

            //Hp��0�ɂȂ����Ƃ��uPlayerDeath�v�ƕ\��
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
            //�f�o�b�O�p
            if (Input.GetKeyDown(KeyCode.Return))
            {
               playerData.Health -= 10;
              
            }
        }
    }
}


