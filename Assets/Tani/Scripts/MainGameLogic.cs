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
    [SerializeField, LabelText("ターン開始時減少するやる気")] int _motivationDownPerTurn = 5;

    [SerializeField, FoldoutGroup("Refs")]EnemyController enemyController;
    [SerializeField, FoldoutGroup("Refs")] UseableCardContainerPresenter useableCardContainer;

    PlayerData _playerData;


    private async void Start()
    {

        _playerData = PlayerData.Instance;




        await InitAsync();
        GameLoop().Forget();


    }

    private async UniTask InitAsync()
    {
        enemyController.SpawnEnemies(0);

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
        //ターン開始時処理
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
        print("カードをドロー");
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();

        await UniTask.Delay(1000);
    }

    private async UniTask HeroPhaseAsync()
    {
        _playerData.Status.ResetTempStatus();
        while (_playerData.Status.RemainingUseCount.Value != 0)
        {
            var usedInfo = await SelectUseCardAsync();
            _playerData.CardManager.UseCard(_playerData.CardManager.HandCardContainer, usedInfo.index);
        }

        _playerData.CardManager.MoveHandCardContainerCardToDiscardContainer();

        await UniTask.Delay(1000);

    }
    private async UniTask BattlePhaseAsync()
    {
        enemyController.TargetEnemy().ApplyDamage(new Damage { damage = _playerData.Status.Attack.Value });

        await UniTask.Delay(1000);

    }

    private  UniTask<IndexIdPair> SelectUseCardAsync()
    {
        var cs = new UniTaskCompletionSource<IndexIdPair>();

        IDisposable disposable = null;

        disposable = 
            useableCardContainer
            .OnCardUseSelected
            .Subscribe(info => 
            {
                Debug.Log("OnCardUsed");
                cs.TrySetResult(info); 
                disposable?.Dispose();
            });

        return cs.Task;
    }



}
