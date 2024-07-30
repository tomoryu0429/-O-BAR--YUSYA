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


    CancellationToken cts;
    
    private async void Start()
    {
        cts = new CancellationToken();
        await InitAsync(cts);
        GameLoop(cts).Forget();


    }

    private async UniTask InitAsync(CancellationToken cts)
    {
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
        await UniTask.Delay(1000);

    }
    private async UniTask DrawPhaseAsync(CancellationToken cts)
    {

        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();
        await UniTask.Delay(1000);

    }

    private async UniTask HeroPhaseAsync(CancellationToken cts)
    {
        //入力受付
       var selectedData =   await SelectCardAsync().Task;

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
