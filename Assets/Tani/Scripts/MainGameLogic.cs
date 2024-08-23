using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading;
using System;
using Tani;
using R3;
using System.Linq;
using Alchemy.Inspector;

public class MainGameLogic : MonoBehaviour
{

    [SerializeField] List<EnemyPackage> _enemyPacks;
    [SerializeField] Transform _enemyParent;

    [SerializeField] bool UseFixedIndex = false;
    [SerializeField,ShowIf(nameof(UseFixedIndex))] int _index = 0;

    CancellationToken cts;
    EnemyPackage _selectedPack;
    List<EnemyBase> _enemies = new();
    PlayerData _playerData;
    EnemyBase _currentPlayerTarget = null;

    private async void Start()
    {
        _playerData = PlayerData.Instance;

        if (!UseFixedIndex)
        {
            int _index = Mathf.FloorToInt(UnityEngine.Random.Range(0, _enemyPacks.Count));

        }
        _selectedPack = _enemyPacks[_index];
         cts = new CancellationToken();
        //_playerCombat = _playerData.gameObject.GetComponent<PlayerCombat>();

        await InitAsync(cts);
        GameLoop(cts).Forget();


    }

    private async UniTask InitAsync(CancellationToken cts)
    {
        _enemies = EnemyPackage.InstEnemies(_selectedPack.EnemyDatas,_enemyParent).ToList();





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
        //ターン開始時処理
        _playerData.Defence = 0;
        _playerData.YP -= 5;

        print($"HP : {_playerData.Health}");
        print($"YP : {_playerData.YP    }");
        print($"DEF : {_playerData.Defence }");

        await UniTask.Delay(1000);

    }
    private async UniTask DrawPhaseAsync(CancellationToken cts)
    {
        print("カードをドロー");
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();
        _playerData.CardManager.DrawCard();


        
    }

    private async UniTask HeroPhaseAsync(CancellationToken cts)
    {
        CardData data = null;

        //カード選択待機
        var selectedData = await SelectCardAsync().Task;
        data = CardSystem.CardSystemUtility.GetCardData(selectedData.Item2);

        //使用したカードの効果を適用
        ApplyCardEffect(data);


        

        await UniTask.Delay(1000);

    }
    private async UniTask BattlePhaseAsync(CancellationToken cts)
    {
        if(_currentPlayerTarget is not null)
        {
            DamageUtility.ApplyDamage((DamageUtility.IDamagable)_currentPlayerTarget, _playerData.Attack);
        }
        else
        {
            DamageUtility.ApplyDamage((DamageUtility.IDamagable)_enemies.Find(e => e is not null), _playerData.Attack);
        }


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

    private void ApplyCardEffect(CardData data)
    {
        print(data.CardName.ToString() + "を使用");

        _playerData.YP += data.YP_Increase;
        _playerData.Defence += data.Def_Increase;


        print($"YPが : {data.YP_Increase   }増加");
        print($"DEFが : {data.Def_Increase }増加");
    }

    public void SetTargetEnemy(EnemyBase enemy)
    {
        _currentPlayerTarget = enemy;
    }
    public void OnEnemyDie(EnemyBase enemy)
    {
        int index = _enemies.FindIndex(e => e == enemy);
        if(index != -1)
        {
            _enemies[index] = null;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException();
        }
    }
}
