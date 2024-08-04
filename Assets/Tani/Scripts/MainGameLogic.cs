using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading;
using System;
using Tani;
using R3;

public class MainGameLogic : MonoBehaviour
{
    [SerializeField]PlayerData _playerData;
    [SerializeField] List<GameObject> _enemyDatas;
    [SerializeField] Transform[] _enemyPoints;

    CancellationToken cts;

    List<EnemyBase> _enemies;

    private async void Start()
    {
        cts = new CancellationToken();
        await InitAsync(cts);
        GameLoop(cts).Forget();


    }

    private async UniTask InitAsync(CancellationToken cts)
    {
        GameObject enemy = Instantiate<GameObject>(_enemyDatas[0], _enemyPoints[0]);
        EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();
        enemyBase.Init(_playerData);
        _enemies.Add(enemyBase);


        await UniTask.Yield(cancellationToken: cts);
        await UniTask.Delay(1000);

       
    }

    private async UniTask GameLoop(CancellationToken cts)
    {
        while (true)
        {
            await StartPhaseAsync(cts);
            await DrawPhaseAsync(cts);
            await HeroPhaseAsync(cts);
            await BattlePhaseAsync(cts);
        }
    }

  

    private async UniTask StartPhaseAsync(CancellationToken cts)
    {
        _playerData.Diffense = 0;
        _playerData.YP -= 5;

        print($"HP : {_playerData.Health}");
        print($"YP : {_playerData.YP    }");
        print($"DEF : {_playerData.Diffense }");

        await UniTask.Delay(1000);

    }
    private async UniTask DrawPhaseAsync(CancellationToken cts)
    {
        print("カードをドロー");
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();
        await UniTask.Delay(1000);

    }

    private async UniTask HeroPhaseAsync(CancellationToken cts)
    {
        //入力受付
       var selectedData =   await SelectCardAsync().Task;
        CardData data = CardSystem.CardSystemUtility.GetCardData(selectedData.Item2);
        print(data.CardName.ToString() + "を使用");

        _playerData.YP += data.YP_Increase;
        _playerData.Diffense += data.Def_Increase;

        print($"YPが : {data.YP_Increase   }増加");
        print($"DEFが : {data.Def_Increase }増加");

        //カード選択待機

        await UniTask.Delay(1000);

    }
    private async UniTask BattlePhaseAsync(CancellationToken cts)
    {
        await UniTask.Delay(1000);

    }

    private UniTaskCompletionSource<(int, AutoEnum.ECardID)> SelectCardAsync()
    {
        var cs = new  UniTaskCompletionSource<(int, AutoEnum.ECardID)>();

        IDisposable disposable = null;

        disposable = _playerData.CardManager.containers[(int)CardManager.EPileType.Hand]
           .OnCardUsed.AsObservable()
           .Subscribe(data =>
           {
               cs.TrySetResult(data);
               disposable?.Dispose();

           });

        return cs;
    }
}
