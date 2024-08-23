using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class EnemyUIBinder : MonoBehaviour
{
    [SerializeField] Image _fillImage;
    [SerializeField] EnemyBase _enemyData;

    MainGameLogic logic;
    private void Start()
    {
        _enemyData.HealthObservable.Subscribe(health =>
        {
            _fillImage.fillAmount = (float)health / (float)_enemyData.HealthValueRange.maxHealth;
        }).AddTo(this);

        logic = FindAnyObjectByType<MainGameLogic>();

        _enemyData.HealthObservable
            .Where(hp => hp == 0)
            .Subscribe(_ =>
            {
                print($"{gameObject.name}‚ð“|‚µ‚½");
                Destroy(this.gameObject);
            }).AddTo(this);


    }

    private void OnClick()
    {
        logic.SetTargetEnemy(_enemyData);        
    }

    private void OnDestroy()
    {
        logic.SetTargetEnemy(null);
        logic.OnEnemyDie(_enemyData);
    }
}
