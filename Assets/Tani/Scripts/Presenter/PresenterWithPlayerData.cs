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


        private void Awake()
        {
            //HP�ɉ�����HPBar�̃Q�[�W��ݒ�
            PlayerData.Instance
                .ReactiveProperty_HP
                .Subscribe(x => hpBar.SetHpPercent(x / 100.0f))
                .AddTo(this);

            //Hp��0�ɂȂ����Ƃ��uPlayerDeath�v�ƕ\��
            PlayerData.Instance
                .ReactiveProperty_HP
                .Where(x => x == 0)
                .Subscribe(_ => print("PlayerDeath"))
                .AddTo(this);
        }



        private void Update()
        {
            //�f�o�b�O�p
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerData.Instance.HP -= 10;
              
            }
        }
    }
}


