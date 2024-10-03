using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System.Threading.Tasks;
using System.Threading;
using System;
using Tani;
using R3;
using System.Linq;
using Alchemy.Inspector;

public class MainGameLogic : MonoBehaviour
{
    [SerializeField, LabelText("�^�[���J�n������������C")] int _motivationDownPerTurn = 5;

    [SerializeField,FoldoutGroup("Refs")]EnemyController enemyController;

    PlayerData _playerData;


    private async void Start()
    {

        _playerData = PlayerData.Instance;




        await InitAsync();
        GameLoop().Forget();


    }

    private async UniTask InitAsync()
    {
        //enemyController.SpawnEnemies();

        await UniTask.Delay(1000); 
    }

    private async UniTask GameLoop()
    {
        while (true)
        {
            await StartPhaseAsync();
            await DrawPhaseAsync();
            await HeroPhaseAsync();
            await BattlePhaseAsync();
        }
    }

  

    private async UniTask StartPhaseAsync()
    {
        //�^�[���J�n������
        _playerData.Status.Guard.Value = 0;
        _playerData.Status.Motivation.Value -= 5;

        print($"HP : {_playerData.Status.Health.Value}");
        print($"YP : {_playerData.Status.Motivation.Value    }");
        print($"DEF : {_playerData.Status.Guard.Value }");

        await UniTask.Create(async () =>
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    break;
                }
                await UniTask.NextFrame();
            }
        });

    }
    private async UniTask DrawPhaseAsync()
    {
        print("�J�[�h���h���[");
        _playerData.CardManager.DrawCard();
        //_playerData.CardManager.DrawCard();
        //_playerData.CardManager.DrawCard();

        while (true)
        {
            await UniTask.Yield();
        }
    }

    private async UniTask HeroPhaseAsync()
    {
        CardData data = null;

        //�J�[�h�I��ҋ@
        //var selectedData = await SelectCardAsync().Task;
        //data = CardSystem.CardSystemUtility.GetCardData(selectedData.Item2);

        ////�g�p�����J�[�h�̌��ʂ�K�p
        //ApplyCardEffect(data);


        await UniTask.Delay(1000);

    }
    private async UniTask BattlePhaseAsync()
    {
        

        await UniTask.Delay(1000);

    }

    //private UniTaskCompletionSource<(int, AutoEnum.ECardID)> SelectCardAsync()
    //{
    //    var cs = new  UniTaskCompletionSource<(int, AutoEnum.ECardID)>();

    //    IDisposable disposable = null;

    //    disposable = _playerData.CardManager.containers[(int)PlayerCardManager.EPileType.Hand]
    //       .OnCardUsed.AsObservable()
    //       .Subscribe(data =>
    //       {
    //           cs.TrySetResult(data);
    //           disposable?.Dispose();

    //       });

    //    return cs;
    //}

    //private void ApplyCardEffect(CardData data)
    //{
    //    print(data.CardName.ToString() + "���g�p");

    //    _playerData.Status.Motivation.Value += data.YP_Increase;
    //    _playerData.Status.Guard.Value += data.Def_Increase;


    //    print($"YP�� : {data.YP_Increase   }����");
    //    print($"DEF�� : {data.Def_Increase }����");
    //}

  
}
