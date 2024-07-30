using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading;
using System;


public class MainGameLogic : MonoBehaviour
{
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
      
    }
    private async UniTask DrawPhaseAsync(CancellationToken cts)
    {

    }

    private async UniTask HeroPhaseAsync(CancellationToken cts)
    {
        //入力受付
        //カード選択待機

    }
    private async UniTask BattlePhaseAsync(CancellationToken cts)
    {
        throw new NotImplementedException();
    }
}
